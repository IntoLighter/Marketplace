import {CartProduct, isAuthenticated} from "./site.js";

function appendCartProductWidget(item: CartProduct, row: JQuery<HTMLDivElement>) {
    $.get('html/cartWidget.html', function (widget: any) {
        widget = $(widget)
        widget.find('.Image').attr('src', item.imageUri)
        widget.find('.Name').text(item.name)
        widget.find('.Weight').text(item.weight)
        widget.find('.Price').text(item.price)
        widget.find('.Shop').attr('src', `img/shops/${item.shopName}.png`)
        widget.find('.Shop').attr('alt', item.shopName)
        widget.find('.Count').text(item.count)
        row.append(widget)
    })
}

let products: CartProduct[] = []

const openRequest = window.indexedDB.open('marketplace', 1)
let objectStore: IDBObjectStore

openRequest.onsuccess = () => {
    objectStore = openRequest.result.transaction('cart', 'readwrite').objectStore('cart')
    const cursorRequest = objectStore.openCursor()

    cursorRequest.onsuccess = e => {
        // @ts-ignore
        const cursor = e.target.result

        function getRow(): JQuery<HTMLDivElement> {
            return $('<div>', {
                'class': 'row-cols-4 row',
            });
        }

        objectStore.count().onsuccess = async e => {
            // @ts-ignore
            if (e.target.result === 0) {
                console.log(`Db doesn't have cart products, trying to fetch from server`)
                if (isAuthenticated()) {
                    await $.get('/Areas/Cart/GetProducts', products, () => {
                        if (products.length === 0) {
                            console.log(`Server also doesn't have cart products`)
                            return
                        } else {
                            $.each(products, (_, product) => {
                                objectStore.add(product)
                            })
                            console.log(`Added products to db`)
                        }
                    })
                }
            } else if (isAuthenticated()) {
                await $.get('Areas/Cart/GetProducts', products, () => {
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

            objectStore.getAll().onsuccess = async e => {
                // @ts-ignore
                products = e.target.result
                let productsLength = products.length;

                let decrementCount = 0;
                if (products.length % 4 !== 0) {
                    while (productsLength % 4 !== 0) {
                        productsLength--
                        decrementCount++
                    }
                }

                const div = $('<div>')

                for (let i = 0; i < productsLength; i += 4) {
                    const row = getRow()
                    appendCartProductWidget(products[i], row)
                    appendCartProductWidget(products[i + 1], row)
                    appendCartProductWidget(products[i + 2], row)
                    appendCartProductWidget(products[i + 3], row)
                    div.append(row)
                }

                if (products.length % 4 !== 0) {
                    const row = getRow()
                    for (let i = 0; i < decrementCount; i++) {
                        appendCartProductWidget(products[i], row)
                    }
                    div.append(row)
                }

                $('main').append(div)
            }
        }
    }
}

$('.delete-from-cart-completely').on('click', async function () {
    const parent = $(this).parent('.Item')
    const id = parent.data('id')
    const shopName = parent.find('.Shop').attr('alt')
    if (isAuthenticated()) {
        await $.post('Areas/Cart/DeleteProductCompletely', {
            id: id,
            shopName: shopName
        }, () => {
            console.log(`{${id}, ${shopName}} deleted completely on server`)
        })
    }

    objectStore.delete([id, shopName])
    window.location.reload()
})
