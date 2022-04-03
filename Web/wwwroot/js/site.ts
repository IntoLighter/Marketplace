export class CartProduct {
    public name: string;
    public price: number;
    public count: number;
    public shopName: string;

    constructor(name, price, count, shopName) {
        this.name = name
        this.price = price
        this.count = count
        this.shopName = shopName
    }
}

export function isAuthenticated(): boolean {
    $.get('Areas/Identity/Account/IsAuthenticated', {}, (resp: boolean) => {
        if (resp) {
            return true
        }
    })
    return false
}

const openRequest = window.indexedDB.open('marketplace', 1);
export let db

openRequest.onsuccess = () => {
    console.log('Db opened successfully')
    db = openRequest.result
}
openRequest.onerror = () => console.log('Db failed to open')

openRequest.onupgradeneeded = e => {
    // @ts-ignore
    db = e.target.result;
    const objectStore = db.createObjectStore('Cart', {keyPath: ['Name', 'ShopName'], autoIncrement: true})
    objectStore.createIndex('Product', 'Product', {unique: false})
    objectStore.createIndex('Count', 'Count', {unique: false})
    console.log('Db set up')
}

const ddData = [
    {
        text: 'Аллея',
        value: 'alley',
        selected: true,
        imageSrc: 'img/shops/alley.png'
    },
    {
        text: 'Fix price',
        value: 'fixprice',
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

$('#Shop').ddsclick({
    data: ddData,
    width: 100,
    imagePosition: 'left'
})

$('.add-to-cart').on('click', function () {
    const parent = $(this).parent()
    const name = parent.find('#Name').text()
    const shopName = parent.find('#Shop').val()
    const count = parent.find('#Count').text()

    const product = new CartProduct(name, parent.find('#Price').text(), count, shopName)

    $.get('Areas/Identity/Account/IsAuthenticated', {}, (resp: boolean) => {
        if (resp) {
            $.post('Areas/Cart/AddProduct', product, () => {
                console.log(`Sent {${name}, ${shopName}}  to server`)
            }).fail(() => console.log(`Failed to send {${name}, ${shopName}} to server`))
        }
    })

    const transaction = db.transaction(['Cart'], 'readwrite')
    const objectStore = db.objectStore('Cart')
    const cursorRequest = objectStore.openCursor()

    transaction.onerror = () => console.log('Transaction to add product failed')

    cursorRequest.onsuccess = e => {
        const cursor = e.target.result
        if (cursor) {
            if (cursor.primaryKey.name === name && cursor.primaryKey.shopName === shopName) {
                cursor.value.count = count
                cursor.update(cursor.value)
                console.log(`Found {${name}, ${shopName}} in db and updated`)
                return
            }
            cursor.continue()
        }
    }
    objectStore.add(product)
    console.log(`Added {${name}, ${shopName}} in db`)
})

$('.delete-from-cart').on('click', function () {
    const parent = $(this).parent()
    const name = parent.find('#Name').text()
    const shopName = parent.find('#Shop').val()

    const transaction = db.transaction(['cart'], 'readwrite')
    const objectStore = transaction.objectStore('cart')
    objectStore.delete([name, shopName])

    transaction.oncomplete = () => {
        parent.remove()
        if (isAuthenticated()) {
            $.post('Areas/Cart/DeleteProduct', {name, shopName},
                () => console.log(`Sent {${name}, ${shopName}} to server`))
                .fail(() => console.log(`Failed to send {${name}, ${shopName}} to server`))
        }
    }

    transaction.onerror = () => console.log('Transaction to delete product failed')
})
