export class CartProduct {
    constructor(productId, name, price, shopName, imageUri, weight) {
        this.count = 1;
        this.productId = productId;
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
    const widget = $(this).parents('.Item');
    switch (widget.data('item-type')) {
        case "product":
            const product = new CartProduct(widget.data('item-id'), widget.find('.Name').text(), widget.find('.Price').text(), widget.find('.dd-selected-text').text(), widget.find('.Image').attr('src'), widget.find('.Weight').text());
            addProduct(product);
            break;
        case "dish":
            $.each(widget.find('.dish').children('.col'), (_, val) => {
                addProduct($(val).data('info'));
            });
            break;
    }
    const count = $(this).parent().find('.Count');
    let newNumber = count.val();
    newNumber++;
    count.val(newNumber);
    widget.parent().find('.delete-from-cart').removeAttr('disabled');
    function addProduct(product) {
        const pk = { productId: product.productId, shopName: product.shopName };
        if (isAuthenticated()) {
            $.post('Areas/Cart/AddProduct', product, () => {
                console.log(`Sent ${JSON.stringify(pk)}  to server`);
            }).fail(() => console.log(`Failed to send {${JSON.stringify(pk)} to server`));
        }
        const { transaction, objectStore, cursorRequest } = getIndexedDbTriplet();
        cursorRequest.onsuccess = e => {
            // @ts-ignore
            const cursor = e.target.result;
            if (cursor) {
                if (cursor.primaryKey[0] === pk.productId && cursor.primaryKey[1] === pk.shopName) {
                    cursor.value.count++;
                    cursor.update(cursor.value);
                    // @ts-ignore
                    console.log(`Found ${JSON.stringify(pk)} in db and updated`);
                    return;
                }
                cursor.continue();
            }
            objectStore.add(product);
            transaction.oncomplete = () => console.log(`Added ${JSON.stringify(pk)} to db`);
        };
        // @ts-ignore
        transaction.onerror = e => console.log(`Transaction to add product failed: ${e.target.error}`);
    }
});
$('.delete-from-cart').on('click', function () {
    const widget = $(this).parents('.Item');
    const shopName = widget.find('.dd-selected-text').text();
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
    let newNumber = count.val();
    newNumber--;
    count.val(newNumber);
    if (newNumber === 0) {
        $(this).attr('disabled', 'disabled');
    }
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
                if (cursor.primaryKey[0] == id && cursor.primaryKey[1] === shopName) {
                    cursor.value.count--;
                    if (cursor.value.count === 0) {
                        objectStore.delete([id, shopName]);
                        transaction.oncomplete = () => console.log(`Deleted {${id}, ${shopName} in db`);
                        return;
                    }
                    cursor.update(cursor.value);
                    transaction.oncomplete = () => console.log(`Found {${id}, ${shopName}} in db and decremented`);
                    return;
                }
                cursor.continue();
            }
        };
        // @ts-ignore
        transaction.onerror = e => console.log(`Transaction to delete product failed: ${e.target.result}`);
    }
});
$('.Count').on('input', function () {
    const widget = $(this).parents('.Item');
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
                        widget.find('.Count').attr('hidden', 'hidden');
                        widget.find('.delete-from-cart').attr('hidden', 'hidden');
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
        imageSrc: '../img/shops/Аллея.png'
    },
    {
        text: 'Fixprice',
        value: 'FixPrice',
        selected: false,
        imageSrc: '../img/shops/Fixprice.png'
    },
    {
        text: 'Лента',
        value: 'Lenta',
        selected: true,
        imageSrc: '../img/shops/Лента.png'
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