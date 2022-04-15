import {CartProduct, isAuthenticated} from "./site.js";

function appendCartWidget(item: CartProduct): JQuery<HTMLDivElement> {
    $.get('~/html/cartWidget.html', function (widget: JQuery<HTMLDivElement>) {
        widget.data('id', item.productId)
        widget.find('.Image').attr('src', item.imageUri)
        widget.find('.Name').text(item.name)
        widget.find('.Weight').text(item.weight)
        widget.find('.Price').text(item.price)
        widget.find('Shop').attr('src', `~/img/shops/${item.shopName}`)
        widget.find('Shop').attr('alt', `${item.shopName}`)
        widget.find('.Count').text(item.count)
        return widget
    })
    throw new Error('Did not find cart widget')
}

let products: CartProduct[] = []

const openRequest = window.indexedDB.open('marketplace', 1)
let cartStore : IDBObjectStore 

openRequest.onsuccess = () => {
    cartStore = openRequest.result.transaction('cart', 'readwrite').objectStore('cart')
    const cursorRequest = cartStore.openCursor()

    cursorRequest.onsuccess = e => {
        // @ts-ignore
        const cursor = e.target.result
        if (!cursor) {
            console.log(`Db doesn't have cart products, trying to fetch from server`)
            if (isAuthenticated()) {
                $.get('/Areas/Cart/GetProducts', products, () => {
                    if (productsLength === 0) {
                        console.log(`Server also doesn't have cart products`)
                        return
                    } else {
                        $.each(products, (_, product) => {
                            cartStore.add(product)
                        })
                        console.log(`Added products to db`)
                    }
                })
            }
        } else if (isAuthenticated()) {
            $.get('Areas/Cart/GetProducts', products, () => {
                if (products.length == 0) {
                    console.log(`Server doesn't have products, uploading to it from db`)
                    if (cursor) {
                        $.post('Areas/Cart/AddProduct', cursor.value)
                    }
                    cursor.continue()
                }
                console.log(`Uploaded products to server`)
            })
        }

        let productsLength = products.length;
        let decrementCount = 0;
        if (products.length % 4 != 0) {
            while (productsLength % 4 != 0) {
                productsLength--
                decrementCount++;
            }
        }

        for (let i = 0; i < productsLength; i += 4) {
            const div = $('<div>', {
                'class': 'row-cols-4 row justify-content-center',
            })
            div.append(appendCartWidget(products[i]))
            div.append(appendCartWidget(products[i + 1]))
            div.append(appendCartWidget(products[i + 2]))
            div.append(appendCartWidget(products[i + 3]))
            $(document).append(div)
        }

        if (products.length % 4 != 0) {
            for (let i = 0; i < decrementCount; i++) {
                appendCartWidget(products[productsLength + i])
            }
        }
    }
}

$('.delete-from-cart-completely').on('click', function () {
    const parent = $(this).parent().parent()
    const id = parent.data('id')
    const shopName = parent.find('.Shop').attr('alt')
    if (isAuthenticated()) {
        $.post('Areas/Cart/DeleteProductCompletely', {
            id: id,
            shopName: shopName
        }, () => {
            console.log(`{${id}, ${shopName}} deleted completely on server`)
        })
    }

    cartStore.delete([id, shopName])
    window.location.reload()
})
