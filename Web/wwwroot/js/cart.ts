import {ajaxDelete, ajaxGet, ajaxPost, CartProduct, isAuthenticated} from "./site.js"

const cartWidget = await $.get('html/cartWidget.html')
const row = $('<div>', {'class': 'row'})

function appendCartProductWidget(product: CartProduct) {
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

    const objectStore = getCartStore()

    objectStore.count().onsuccess = async e => {
        // @ts-ignore
        if (e.target.result === 0) {
            if (await isAuthenticated()) {
                products = await ajaxGet()
                const objectStore = getCartStore()

                if (products.length === 0) {
                    return
                } else {
                    $.each(products, function () {
                        objectStore.put(this)
                    })
                }
            }
        } else if (await isAuthenticated()) {
            products = await ajaxGet()
            if (products.length == 0) {

                const objectStore = getCartStore()
                objectStore.openCursor().onsuccess = e => {
                    // @ts-ignore
                    const cursor = e.target.result
                    if (cursor) {
                        ajaxPost(cursor.value, cursor.primaryKey)
                        cursor.continue()
                    }
                }
            }
        }

        const objectStore = getCartStore()
        objectStore.getAll().onsuccess = e => {
            // @ts-ignore
            products = e.target.result

            $.each(products, function () {
                appendCartProductWidget(this)
            })
            
            $('main').append(row)
        }
    }
}

$('main').on('click', '.delete-from-cart-completely', async function () {
    const parent = $(this).parents('.Item')
    const id = parent.data('id')
    const shopName = parent.find('.Shop').attr('alt')
    const pk = [id, shopName]

    if (await isAuthenticated()) {
        ajaxDelete('DeleteCompletely', pk)
    }

    const objectStore = getCartStore()
    objectStore.delete([id, shopName])

    window.location.reload()
})

function getCartStore() {
    return db.transaction('cart', 'readwrite').objectStore('cart')
}
