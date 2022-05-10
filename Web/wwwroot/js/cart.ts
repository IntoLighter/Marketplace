import {CartProduct, isAuthenticated} from "./site.js"

const cartWidget = await $.get('html/cartWidget.html')

function appendCartProductWidget(product: CartProduct, row: JQuery<HTMLDivElement>) {
    const widget = $(cartWidget)
    widget.data('id', product.id)
    widget.find('.Image').attr('src', product.imageUri)
    widget.find('.Name').text(product.name)
    widget.find('.Weight').text(product.weight)
    widget.find('.Price').text(product.price)
    widget.find('.Shop').attr('src', `img/shops/${product.shopName}.png`)
    widget.find('.Shop').attr('alt', product.shopName)
    widget.find('.Count').text(product.count)
    row.append(widget)
}

let products: CartProduct[] = []

const openRequest = window.indexedDB.open('marketplace', 1)
let db: IDBDatabase

openRequest.onsuccess = () => {
    db = openRequest.result
    const [transaction, objectStore, cursorRequest] = getIndexedDbTriplet()

    cursorRequest.onsuccess = e => {
        // @ts-ignore
        const cursor = e.target.result

        // @ts-ignore
        objectStore.count().onsuccess = async e => {
            // @ts-ignore
            if (e.target.result === 0) {
                console.log(`Db doesn't have cart products, trying to fetch from server`)
                if (await isAuthenticated()) {
                    $.get('/Areas/Cart/GetProducts', products, () => {

                        const [transaction, objectStore, cursorRequest] = getIndexedDbTriplet()

                        if (products.length === 0) {
                            console.log(`Server also doesn't have cart products`)
                            return
                        } else {
                            $.each(products, function () {
                                objectStore.put($(this))
                            })
                            console.log(`Added products to db`)
                        }
                    })
                }
            } else if (await isAuthenticated()) {
                $.get('Areas/Cart/GetProducts', products, () => {

                    if (products.length == 0) {
                        console.log(`Server doesn't have products, uploading to it from db`)

                        const [transaction, objectStore, cursorRequest] = getIndexedDbTriplet()
                        cursorRequest.onsuccess = e => {
                            if (cursor) {
                                $.post('Areas/Cart/AddProduct', cursor.value)
                            }
                            cursor.continue()
                            console.log(`Uploaded products to server`)
                        }
                    }
                })
            }

            const [transaction, objectStore, cursorRequest] = getIndexedDbTriplet()
            objectStore.getAll().onsuccess = e => {
                // @ts-ignore
                products = e.target.result
                let productsLength = products.length

                let decrementCount = 0
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

    function getRow(): JQuery<HTMLDivElement> {
        return $('<div>', {
            'class': 'row row-cols-4',
        })
    }
}

$('main').on('click', '.delete-from-cart-completely', async function () {
    const parent = $(this).parents('.Item')
    const id = parent.data('id')
    const shopName = parent.find('.Shop').attr('alt')
    const pk = {id: id, shopName: shopName}
    console.log(pk)
    
    if (await isAuthenticated()) {
        $.post('Areas/Cart/DeleteProductCompletely', {
            id: id,
            shopName: shopName
        }, () => {
            console.log(`${JSON.stringify(pk)} deleted completely on server`)
        })
    }
    
    const [transaction, objectStore, cursorRequest] = getIndexedDbTriplet()

    objectStore.delete([id, shopName])

    // @ts-ignore
    transaction.onerror = e => console.log(`Transaction to delete product ${JSON.stringify(pk)} failed: ${e.target.error}`)
    window.location.reload()
})

function getIndexedDbTriplet() : [IDBTransaction, IDBObjectStore, IDBRequest] {
    const transaction = db.transaction('cart', 'readwrite')
    const objectStore = transaction.objectStore('cart')
    const cursorRequest = objectStore.openCursor()
    return [transaction, objectStore, cursorRequest]
}
