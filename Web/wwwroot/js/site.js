export class CartProduct {
    constructor(id, name, price, shopName, imageUri, weight) {
        this.count = 1;
        this.id = id;
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
    db.createObjectStore('cart', { keyPath: ['id', 'shopName'] });
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
        const pk = { id: product.id, shopName: product.shopName };
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
                if (cursor.primaryKey[0] === pk.id && cursor.primaryKey[1] === pk.shopName) {
                    cursor.value.count++;
                    cursor.update(cursor.value);
                    // @ts-ignore
                    console.log(`Found ${JSON.stringify(pk)} in db and updated`);
                    return;
                }
                cursor.continue();
            }
            // @ts-ignore
            objectStore.put(product);
            transaction.oncomplete = () => console.log(`Added ${JSON.stringify(pk)} to db`);
        };
        // @ts-ignore
        transaction.onerror = e => console.log(`Transaction to add product failed: ${JSON.stringify(pk)} ${e.target.error}`);
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
        const pk = { id: id, shopName: shopName };
        if (isAuthenticated()) {
            $.post('Areas/Cart/Delete', { id, shopName }, () => console.log(`Sent ${JSON.stringify(pk)} to server`))
                .fail(() => console.log(`Failed to send ${JSON.stringify(pk)} to server`));
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
                        transaction.oncomplete = () => console.log(`Deleted ${JSON.stringify(pk)} in db`);
                        return;
                    }
                    cursor.update(cursor.value);
                    transaction.oncomplete = () => console.log(`Found ${JSON.stringify(pk)} in db and decremented`);
                    return;
                }
                cursor.continue();
            }
        };
        // @ts-ignore
        transaction.onerror = e => console.log(`Transaction to delete product ${JSON.stringify(pk)} failed: ${e.target.result}`);
    }
});
$('.Count').on('input', function () {
    const widget = $(this).parents('.Item');
    const shopName = widget.find('.Shop').val();
    const countWidget = widget.find('.Count');
    const count = countWidget.val();
    if (count < 0) {
        countWidget.val(0);
        return;
    }
    switch (widget.data('item-type')) {
        case "product":
            const product = new CartProduct(widget.data('item-id'), widget.find('.Name').text(), widget.find('.Price').text(), widget.find('.dd-selected-text').text(), widget.find('.Image').attr('src'), widget.find('.Weight').text());
            product.count = count;
            updateCount(product);
            break;
        case "dish":
            $.each(widget.find('.dish').children('.col'), (_, val) => {
                const product = $(val).data('info');
                product.count = count;
                updateCount(product);
            });
            break;
    }
    function updateCount(product) {
        const id = product.id;
        const shopName = product.shopName;
        const pk = { id: id, shopName: shopName };
        if (isAuthenticated()) {
            $.post('Areas/Cart/UpdateCount', { id, shopName }, () => console.log(`Sent ${JSON.stringify(pk)} to server`))
                .fail(() => console.log(`Failed to send ${JSON.stringify(pk)} to server`));
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
                        console.log(`Found ${JSON.stringify(pk)} in db and deleted`);
                    }
                    cursor.update(cursor.value);
                    return;
                }
                cursor.continue();
                objectStore.put(product).onsuccess = () => console.log(`Added product ${pk} to db`);
            }
        };
        // @ts-ignore
        transaction.onerror = e => console.log(`Transaction to delete product ${JSON.stringify(pk)} failed: ${e.target.error}`);
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
function getIndexedDbTriplet() {
    const transaction = db.transaction('cart', 'readwrite');
    const objectStore = transaction.objectStore('cart');
    const cursorRequest = objectStore.openCursor();
    return { transaction, objectStore, cursorRequest };
}
export function isAuthenticated() {
    $.get(`/Identity/Account/IsAuthenticated`, {}, (resp) => {
        return resp;
    });
    return false;
}
//# sourceMappingURL=site.js.map