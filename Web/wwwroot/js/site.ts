export class CartProduct {
    readonly productId: number
    readonly name: string
    readonly price: number
    readonly shopName: string
    readonly imageUri: string
    readonly weight: string
    readonly count = 1

    constructor(id: number, name: string, price: number, shopName: string, imageUri: string, weight: string) {
        this.productId = id
        this.name = name
        this.price = price
        this.shopName = shopName
        this.imageUri = imageUri
        this.weight = weight
    }
}

const openRequest = window.indexedDB.open('marketplace', 1)

let db: IDBDatabase
openRequest.onsuccess = () => {
    console.log('Db opened successfully')
    db = openRequest.result
}

openRequest.onerror = () => console.log('Db failed to open')
openRequest.onupgradeneeded = e => {
    // @ts-ignore
    db = e.target.result;
    const objectStore = db.createObjectStore('cart', {keyPath: ['productId', 'shopName']})
    console.log('Db set up')
}


$('.add-to-cart').on('click', function () {
    const widget = $(this).parent().parent()
    switch (widget.data('item-type')) {
        case "dish":
            const product = new CartProduct(
                widget.data('item-id') as number,
                widget.find('.Name').text(),
                widget.find('.Price').text() as unknown as number,
                widget.find('.ShopName').val() as string,
                widget.find('.Image').attr('src') as string,
                widget.find('.Weight').text())
            addProduct(product)
            break;
        case "product":
            $.each(widget.find('.dish').children('.col'), (_, val) => {
                addProduct($(val).data('info') as CartProduct)
            })
            break;
    }

    const count = $(this).parent().find('.Count')
    count.val(count.val() as number + 1)

    function addProduct(product: CartProduct) {
        if (isAuthenticated()) {
            $.post('Areas/Cart/AddProduct', product, () => {
                console.log(`Sent {${id}, ${shopName}}  to server`)
            }).fail(() => console.log(`Failed to send {${id}, ${shopName}} to server`))
        }

        const id = product.productId
        const shopName = product.shopName

        const {transaction, objectStore, cursorRequest} = getIndexedDbTriplet();

        cursorRequest.onsuccess = e => {
            // @ts-ignore
            const cursor = e.target.result
            if (cursor) {
                if (cursor.primaryKey.id === id && cursor.primaryKey.shopName === shopName) {
                    cursor.value.count++
                    cursor.update(cursor.value)
                    console.log(`Found {${id}, ${shopName}} in db and updated`)
                    return
                }
                cursor.continue()
            }
        }
        objectStore.add(product)
        console.log(`Added {${id}, ${shopName}} to db`)

        transaction.onerror = () => console.log('Transaction to add product failed')
    }
})

$('.delete-from-cart').on('click', function () {
    const widget = $(this).parent().parent()
    const shopName = widget.find('.Shop').val() as string
    switch (widget.data('item-type')) {
        case "product":
            deleteProduct(widget.data('item-id') as number, shopName)
            break;
        case "dish":
            $.each(widget.find('.dish').children('.col'), (_, val) => {
                deleteProduct($(val).data('info').Id as number, shopName)
            })
            break;
    }

    const count = $(this).parent().find('.Count')
    count.val(count.val() as number - 1)

    function deleteProduct(id: number, shopName: string) {
        if (isAuthenticated()) {
            $.post('Areas/Cart/Delete', {id, shopName},
                () => console.log(`Sent {${id}, ${shopName}} to server`))
                .fail(() => console.log(`Failed to send {${id}, ${shopName}} to server`))
        }

        const {transaction, objectStore, cursorRequest} = getIndexedDbTriplet();

        cursorRequest.onsuccess = e => {
            // @ts-ignore
            const cursor = e.target.result
            if (cursor) {
                if (cursor.primaryKey.id == id && cursor.primaryKey.shopName === shopName) {
                    cursor.value.count--
                    if (cursor.value.count === 0) {
                        objectStore.delete([id, shopName])
                        hideCountInputAndDeleteButton(widget)
                    }
                    cursor.update(cursor.value)
                    console.log(`Found {${id}, ${shopName}} in db and deleted`)
                    return
                }
                cursor.continue()
            }
        }

        objectStore.delete([id, shopName])
        transaction.onerror = () => console.log('Transaction to delete product failed')
    }
})

function hideCountInputAndDeleteButton(widget: JQuery<HTMLElement>) {
    widget.find('.Count').attr('hidden', 'hidden')
    widget.find('.delete-from-cart').attr('hidden', 'hidden')
}

$('.Count').on('input', function () {
    const widget = $(this).parent().parent()
    const shopName = widget.find('.Shop').val() as string
    const count = widget.find('.Count').val() as number
    switch (widget.data('item-type') as string) {
        case "product":
            updateCount(widget.data('item-id') as number, shopName, count)
            break;
        case "dish":
            $.each(widget.find('.dish').children('.col'), (_, val) => {
                updateCount($(val).data('info').Id as number, shopName, count)
            })
            break;
    }


    function updateCount(id: number, shopName: string, count: number) {
        if (isAuthenticated()) {
            $.post('Areas/Cart/UpdateCount', {id, shopName},
                () => console.log(`Sent {${id}, ${shopName}} to server`))
                .fail(() => console.log(`Failed to send {${id}, ${shopName}} to server`))
        }

        const {transaction, objectStore, cursorRequest} = getIndexedDbTriplet();

        cursorRequest.onsuccess = e => {
            // @ts-ignore
            const cursor = e.target.result
            if (cursor) {
                if (cursor.primaryKey.id == id && cursor.primaryKey.shopName === shopName) {
                    cursor.value.count = count
                    if (cursor.value.count === 0) {
                        objectStore.delete([id, shopName])
                        hideCountInputAndDeleteButton(widget);
                    }
                    cursor.update(cursor.value)
                    console.log(`Found {${id}, ${shopName}} in db and deleted`)
                    return
                }
                cursor.continue()
            }
        }

        objectStore.delete([id, shopName])

        transaction.onerror = () => console.log('Transaction to delete product failed')
    }
})

const ddData = [
    {
        text: 'Аллея',
        value: 'alleya',
        selected: false,
        imageSrc: 'img/shops/alley.png'
    },
    {
        text: 'Fix price',
        value: 'fixpricefd',
        selected: false,
        imageSrc: 'img/shops/fixprice.png'
    },
    {
        text: 'Лента',
        value: 'lenta',
        selected: true,
        imageSrc: 'img/shops/lenta.png'
    }
]

// @ts-ignore
$('.Shop').ddslick({
    data: ddData,
    width: 100,
    imagePosition: 'left',
    onSelected: function (selected: any) {
        console.log(selected)
        const select = $(this).parent();
        const counts = select.data('prices')
        select.parent().parent().find('.Price').text(counts[selected.val()])
    }
})

export function getIndexedDbTriplet() {
    const transaction = db.transaction('cart', 'readwrite')
    const objectStore = transaction.objectStore('cart')
    const cursorRequest = objectStore.openCursor()
    return {transaction, objectStore, cursorRequest};
}

export function isAuthenticated() {
    $.get(`/Identity/Account/IsAuthenticated`, {}, (resp: boolean) => {
        if (resp) {
            return true
        }
    })
    return false
}
