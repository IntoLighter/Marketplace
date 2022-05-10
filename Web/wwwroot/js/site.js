export class CartProduct {
    id;
    name;
    imageUri;
    weight;
    price;
    shopName;
    count = 1;
    constructor(id, name, price, shopName, imageUri, weight) {
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
    db = openRequest.result;
};
openRequest.onupgradeneeded = () => {
    db = openRequest.result;
    db.createObjectStore('cart', { keyPath: ['id', 'shopName'] });
};
$('.add-to-cart').on('click', async function () {
    const widget = $(this).parents('.Item');
    const shopName = widget.find('.dd-selected-value').val();
    const countWidget = $(this).parent().find('.Count');
    let newCount = Number(countWidget.val()) + 1;
    countWidget.val(newCount);
    if (newCount - 1 === 0) {
        activateDeleteButton(widget);
    }
    switch (widget.data('item-type')) {
        case "product":
            await addProduct(constructProduct(widget));
            break;
        case "dish":
            $.each(widget.find('.product'), async function () {
                await addProduct(constructConstituentProduct($(this), 1, shopName));
            });
            break;
    }
    async function addProduct(product) {
        const pk = [product.id, product.shopName];
        if (await isAuthenticated()) {
            $.post('Areas/Cart/AddProduct', product, () => {
                console.log(`Sent ${JSON.stringify(pk)}  to server`);
            }).fail(() => console.log(`Failed to send {${JSON.stringify(pk)} to server`));
        }
        const objectStore = getCartStore();
        objectStore.get(pk).onsuccess = e => {
            // @ts-ignore
            let result = e.target.result;
            if (result) {
                result.count++;
            }
            else {
                result = product;
            }
            objectStore.put(result);
        };
    }
});
$('.delete-from-cart').on('click', async function () {
    const widget = $(this).parents('.Item');
    const shopName = widget.find('.dd-selected-value').val();
    const countWidget = $(this).parent().find('.Count');
    let newCount = Number(countWidget.val()) - 1;
    countWidget.val(newCount);
    if (newCount === 0) {
        disableDeleteButton(widget);
    }
    switch (widget.data('item-type')) {
        case "product":
            await deleteProduct(widget.data('item-id'), shopName);
            break;
        case "dish":
            $.each(widget.find('.product'), async function () {
                await deleteProduct($(this).data('info').id, shopName);
            });
            break;
    }
    async function deleteProduct(id, shopName) {
        const pk = [id, shopName];
        if (await isAuthenticated()) {
            $.post('Areas/Cart/Delete', { id: id, shopName: shopName }, () => console.log(`Sent ${JSON.stringify(pk)} to server`))
                .fail(() => console.log(`Failed to send ${JSON.stringify(pk)} to server`));
        }
        const objectStore = getCartStore();
        objectStore.get(pk).onsuccess = e => {
            // @ts-ignore
            let result = e.target.result;
            const count = result.count = result.count - 1;
            if (count === 0) {
                objectStore.delete(pk);
            }
            else {
                objectStore.put(result);
            }
        };
    }
});
$('.Count').on('change', async function () {
    const widget = $(this).parents('.Item');
    const shopName = widget.find('.dd-selected-value').val();
    const countWidget = widget.find('.Count');
    const count = Number(countWidget.val());
    if (count < 0) {
        countWidget.val(0);
        disableDeleteButton(widget);
        return;
    }
    switch (widget.data('item-type')) {
        case "product":
            const product = constructProduct(widget);
            product.count = count;
            await updateCount(product);
            break;
        case "dish":
            $.each(widget.find('.product'), async function () {
                await updateCount(constructConstituentProduct($(this), count, shopName));
            });
            break;
    }
    async function updateCount(product) {
        const pk = [product.id, product.shopName];
        if (await isAuthenticated()) {
            $.post('Areas/Cart/UpdateCount', product, () => console.log(`Sent ${JSON.stringify(pk)} to server`))
                .fail(() => console.log(`Failed to send ${JSON.stringify(pk)} to server`));
        }
        const objectStore = getCartStore();
        objectStore.get(pk).onsuccess = () => {
            if (count === 0) {
                objectStore.delete([product.id, product.shopName]);
                disableDeleteButton(widget);
            }
            else {
                objectStore.put(product);
            }
        };
    }
});
const ddData = [
    {
        text: 'Аллея',
        value: 'alley',
        selected: false,
        imageSrc: '../img/shops/alley.png'
    },
    {
        text: 'Fixprice',
        value: 'fixPrice',
        selected: false,
        imageSrc: '../img/shops/fixPrice.png'
    },
    {
        text: 'Лента',
        value: 'lenta',
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
        const parent = $(selected.selectedItem).parents('.Item');
        const prices = parent.data('prices');
        parent.find('.Count').val(0);
        // @ts-ignore
        parent.find('.Price').text(prices[selected.selectedData.value]);
    }
});
function constructConstituentProduct(productWidget, count, shopName) {
    const product = productWidget.data('info');
    product.price = productWidget.data('prices')[shopName];
    product.shopName = shopName;
    product.count = count;
    return product;
}
function constructProduct(widget) {
    return new CartProduct(widget.data('item-id'), widget.find('.Name').text(), widget.find('.Price').text(), widget.find('.dd-selected-value').val(), widget.find('.Image').attr('src'), widget.find('.Weight').text());
}
function activateDeleteButton(widget) {
    widget.parent().find('.delete-from-cart').removeAttr('disabled');
}
function disableDeleteButton(widget) {
    widget.find('.delete-from-cart').attr('disabled', 'disabled');
}
function getCartStore() {
    return db.transaction('cart', 'readwrite').objectStore('cart');
}
export async function isAuthenticated() {
    return $.get(`/Identity/Account/IsAuthenticated`, {}, (resp) => {
        return resp;
    });
}
//# sourceMappingURL=site.js.map