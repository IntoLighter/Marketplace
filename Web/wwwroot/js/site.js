export class CartProduct {
    constructor(id, name, price, shopName, imageUri, weight) {
        this.count = 1;
        this.productId = id;
        this.name = name;
        this.price = price;
        this.shopName = shopName;
        this.imageUri = imageUri;
        this.weight = weight;
    }
}
const openRequest = window.indexedDB.open('marketplace', 1);
let db;
openRequest.onsuccess = () => {
    console.log('Db opened successfully');
    db = openRequest.result;
};
openRequest.onerror = () => console.log('Db failed to open');
openRequest.onupgradeneeded = e => {
    // @ts-ignore
    db = e.target.result;
    const objectStore = db.createObjectStore('cart', { keyPath: ['productId', 'shopName'] });
    console.log('Db set up');
};
$('.add-to-cart').on('click', function () {
    const widget = $(this).parent().parent();
    switch (widget.data('item-type')) {
        case "dish":
            const product = new CartProduct(widget.data('item-id'), widget.find('.Name').text(), widget.find('.Price').text(), widget.find('.ShopName').val(), widget.find('.Image').attr('src'), widget.find('.Weight').text());
            addProduct(product);
            break;
        case "product":
            $.each(widget.find('.dish').children('.col'), (_, val) => {
                addProduct($(val).data('info'));
            });
            break;
    }
    const count = $(this).parent().find('.Count');
    count.val(count.val() + 1);
    function addProduct(product) {
        if (isAuthenticated()) {
            $.post('Areas/Cart/AddProduct', product, () => {
                console.log(`Sent {${id}, ${shopName}}  to server`);
            }).fail(() => console.log(`Failed to send {${id}, ${shopName}} to server`));
        }
        const id = product.productId;
        const shopName = product.shopName;
        const { transaction, objectStore, cursorRequest } = getIndexedDbTriplet();
        cursorRequest.onsuccess = e => {
            // @ts-ignore
            const cursor = e.target.result;
            if (cursor) {
                if (cursor.primaryKey.id === id && cursor.primaryKey.shopName === shopName) {
                    cursor.value.count++;
                    cursor.update(cursor.value);
                    console.log(`Found {${id}, ${shopName}} in db and updated`);
                    return;
                }
                cursor.continue();
            }
        };
        objectStore.add(product);
        console.log(`Added {${id}, ${shopName}} to db`);
        transaction.onerror = () => console.log('Transaction to add product failed');
    }
});
$('.delete-from-cart').on('click', function () {
    const widget = $(this).parent().parent();
    const shopName = widget.find('.Shop').val();
    switch (widget.data('item-type')) {
        case "product":
            deleteProduct(widget.data('item-id'), shopName);
            break;
        case "dish":
            $.each(widget.find('.dish').children('.col'), (_, val) => {
                deleteProduct($(val).data('info').Id, shopName);
            });
            break;
    }
    const count = $(this).parent().find('.Count');
    count.val(count.val() - 1);
    function deleteProduct(id, shopName) {
        if (isAuthenticated()) {
            $.post('Areas/Cart/Delete', { id, shopName }, () => console.log(`Sent {${id}, ${shopName}} to server`))
                .fail(() => console.log(`Failed to send {${id}, ${shopName}} to server`));
        }
        const { transaction, objectStore, cursorRequest } = getIndexedDbTriplet();
        cursorRequest.onsuccess = e => {
            // @ts-ignore
            const cursor = e.target.result;
            if (cursor) {
                if (cursor.primaryKey.id == id && cursor.primaryKey.shopName === shopName) {
                    cursor.value.count--;
                    if (cursor.value.count === 0) {
                        objectStore.delete([id, shopName]);
                        hideCountInputAndDeleteButton(widget);
                    }
                    cursor.update(cursor.value);
                    console.log(`Found {${id}, ${shopName}} in db and deleted`);
                    return;
                }
                cursor.continue();
            }
        };
        objectStore.delete([id, shopName]);
        transaction.onerror = () => console.log('Transaction to delete product failed');
    }
});
function hideCountInputAndDeleteButton(widget) {
    widget.find('.Count').attr('hidden', 'hidden');
    widget.find('.delete-from-cart').attr('hidden', 'hidden');
}
$('.Count').on('input', function () {
    const widget = $(this).parent().parent();
    const shopName = widget.find('.Shop').val();
    const count = widget.find('.Count').val();
    switch (widget.data('item-type')) {
        case "product":
            updateCount(widget.data('item-id'), shopName, count);
            break;
        case "dish":
            $.each(widget.find('.dish').children('.col'), (_, val) => {
                updateCount($(val).data('info').Id, shopName, count);
            });
            break;
    }
    function updateCount(id, shopName, count) {
        if (isAuthenticated()) {
            $.post('Areas/Cart/UpdateCount', { id, shopName }, () => console.log(`Sent {${id}, ${shopName}} to server`))
                .fail(() => console.log(`Failed to send {${id}, ${shopName}} to server`));
        }
        const { transaction, objectStore, cursorRequest } = getIndexedDbTriplet();
        cursorRequest.onsuccess = e => {
            // @ts-ignore
            const cursor = e.target.result;
            if (cursor) {
                if (cursor.primaryKey.id == id && cursor.primaryKey.shopName === shopName) {
                    cursor.value.count = count;
                    if (cursor.value.count === 0) {
                        objectStore.delete([id, shopName]);
                        hideCountInputAndDeleteButton(widget);
                    }
                    cursor.update(cursor.value);
                    console.log(`Found {${id}, ${shopName}} in db and deleted`);
                    return;
                }
                cursor.continue();
            }
        };
        objectStore.delete([id, shopName]);
        transaction.onerror = () => console.log('Transaction to delete product failed');
    }
});
const ddData = [
    {
        text: 'Аллея',
        value: 'Alley',
        selected: false,
        imageSrc: '../img/shops/alley.png'
    },
    {
        text: 'Fixprice',
        value: 'FixPrice',
        selected: false,
        imageSrc: '../img/shops/fixprice.png'
    },
    {
        text: 'Лента',
        value: 'Lenta',
        selected: true,
        imageSrc: '../img/shops/lenta.png'
    }
];
// @ts-ignore
$('.Shop').ddslick({
    data: ddData,
    imagePosition: 'left',
    onSelected: (selected) => {
        //@ts-ignore
        const select = $(selected.selectedItem).parents('.Item');
        const prices = select.data('prices');
        if (!prices)
            return;
        // @ts-ignore
        select.find('.Price').text(prices[selected.selectedData.value]);
    }
});
export function getIndexedDbTriplet() {
    const transaction = db.transaction('cart', 'readwrite');
    const objectStore = transaction.objectStore('cart');
    const cursorRequest = objectStore.openCursor();
    return { transaction, objectStore, cursorRequest };
}
export function isAuthenticated() {
    $.get(`/Identity/Account/IsAuthenticated`, {}, (resp) => {
        if (resp) {
            return true;
        }
    });
    return false;
}
//# sourceMappingURL=site.js.map