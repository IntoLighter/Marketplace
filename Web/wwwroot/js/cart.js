import { ajaxDelete, ajaxGet, ajaxPost, isAuthenticated } from "./site.js";
const cartWidget = await $.get('html/cartWidget.html');
function appendCartProductWidget(product, row) {
    const widget = $(cartWidget);
    widget.data('id', product.id);
    widget.find('.Image').attr('src', product.imageUri);
    widget.find('.Name').text(product.name);
    widget.find('.Weight').text(product.weight);
    widget.find('.Price').text(product.price);
    widget.find('.Shop').attr('src', `img/shops/${product.shopName}.png`);
    widget.find('.Shop').attr('alt', product.shopName);
    widget.find('.Count').text(product.count);
    row.append(widget);
}
let products = [];
const openRequest = window.indexedDB.open('marketplace', 1);
let db;
openRequest.onsuccess = () => {
    db = openRequest.result;
    const objectStore = getCartStore();
    objectStore.count().onsuccess = async (e) => {
        // @ts-ignore
        if (e.target.result === 0) {
            console.log(`Db doesn't have cart products, trying to fetch from server`);
            if (await isAuthenticated()) {
                products = await ajaxGet();
                const objectStore = getCartStore();
                if (products.length === 0) {
                    console.log(`Server also doesn't have cart products`);
                    return;
                }
                else {
                    $.each(products, function () {
                        objectStore.put(this);
                    });
                    console.log(`Added products to db`);
                }
            }
        }
        else if (await isAuthenticated()) {
            products = await ajaxGet();
            if (products.length == 0) {
                console.log(`Server doesn't have products, uploading to it from db`);
                const objectStore = getCartStore();
                objectStore.openCursor().onsuccess = e => {
                    // @ts-ignore
                    const cursor = e.target.result;
                    if (cursor) {
                        ajaxPost(cursor.value, cursor.primaryKey);
                        console.log(`Uploaded ${cursor.value} to server`);
                        cursor.continue();
                    }
                };
            }
        }
        const objectStore = getCartStore();
        objectStore.getAll().onsuccess = e => {
            // @ts-ignore
            products = e.target.result;
            let productsLength = products.length;
            let decrementCount = 0;
            while (productsLength % 4 !== 0) {
                productsLength--;
                decrementCount++;
            }
            const div = $('<div>');
            for (let i = 0; i < productsLength; i += 4) {
                const row = getRow();
                appendCartProductWidget(products[i], row);
                appendCartProductWidget(products[i + 1], row);
                appendCartProductWidget(products[i + 2], row);
                appendCartProductWidget(products[i + 3], row);
                div.append(row);
            }
            if (decrementCount !== 0) {
                const row = getRow();
                for (let i = 0; i < decrementCount; i++) {
                    appendCartProductWidget(products[productsLength + i], row);
                }
                div.append(row);
            }
            $('main').append(div);
        };
    };
    function getRow() {
        return $('<div>', {
            'class': 'row row-cols-4',
        });
    }
};
$('main').on('click', '.delete-from-cart-completely', async function () {
    const parent = $(this).parents('.Item');
    const id = parent.data('id');
    const shopName = parent.find('.Shop').attr('alt');
    const pk = [id, shopName];
    if (await isAuthenticated()) {
        ajaxDelete('DeleteCompletely', pk);
    }
    const objectStore = getCartStore();
    objectStore.delete([id, shopName]);
    window.location.reload();
});
function getCartStore() {
    return db.transaction('cart', 'readwrite').objectStore('cart');
}
//# sourceMappingURL=cart.js.map