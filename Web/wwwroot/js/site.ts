export class CartProduct {
    readonly id: number
    readonly name: string
    readonly imageUri: string
    readonly weight: number
    price: number
    shopName: string
    count = 1

    constructor(id: number, name: string, price: number, shopName: string, imageUri: string, weight: number) {
        this.id = id
        this.name = name
        this.price = price
        this.shopName = shopName
        this.imageUri = imageUri
        this.weight = weight
    }
}

if ('serviceWorker' in navigator) {
    navigator.serviceWorker.register('/sw.js')
}

const openRequest = window.indexedDB.open('marketplace', 1)
const verificationToken = $('input:hidden[name="__RequestVerificationToken"]').val() as string
let db: IDBDatabase

openRequest.onsuccess = () => {
    db = openRequest.result
}

openRequest.onupgradeneeded = () => {
    db = openRequest.result
    db.createObjectStore('cart', {keyPath: ['id', 'shopName']})
}

export function ajaxPost(data: object, pk: (number | string)[]) {
    $.ajax({
        url: `/Areas/Cart/Product/Add`,
        method: 'post',
        contentType: 'application/json',
        data: JSON.stringify(data),
        headers: {
            RequestVerificationToken: verificationToken
        }
    })
}

export function ajaxGet() {
    return $.ajax({
        url: `/Areas/Cart/Product/Read`,
        method: 'get',
        headers: {
            RequestVerificationToken: verificationToken
        },
        success: (resp: object[]) => resp,
        error: (xhr) => console.log(`Failed to read from server: ${xhr.responseText}`)
    })
}

export function ajaxDelete(action: string, pk: (number | string)[]) {
    $.ajax({
        url: `/Areas/Cart/Product/${action}?id=${pk[0]}&shopName=${pk[1]}`,
        method: 'delete',
        headers: {
            RequestVerificationToken: verificationToken
        }
    })
}

$('.add-to-cart').on('click', async function () {
    Notification.requestPermission().then(result => {
        if (result === 'granted') {
            new Notification('ШОК ЦЕНА', {body: `При покупке 10 штук этого же скидка 20%.`})
        }
    })

    const widget = $(this).parents('.Item')
    const shopName = widget.find('.dd-selected-value').val() as string

    const countWidget = $(this).parent().find('.Count')
    let newCount = Number(countWidget.val()) + 1
    countWidget.val(newCount)
    if (newCount - 1 === 0) {
        activateDeleteButton(widget)
    }

    switch (widget.data('item-type')) {
        case "product":
            addProduct(constructProduct(widget))
            break
        case "dish":
            $.each(widget.find('.product'), async function () {
                addProduct(constructConstituentProduct($(this), 1, shopName))
            })
            break
    }

    function addProduct(product: CartProduct) {
        const pk = [product.id, product.shopName]

        const objectStore = getCartStore()

        objectStore.get(pk).onsuccess = async e => {
            // @ts-ignore
            let result = e.target.result as CartProduct
            if (result) {
                result.count++
            } else {
                result = product
            }

            objectStore.put(result)

            if (await isAuthenticated()) {
                ajaxPost(result, pk)
            }
        }
    }
})

$('.delete-from-cart').on('click', async function () {
    const widget = $(this).parents('.Item')
    const shopName = widget.find('.dd-selected-value').val() as string

    const countWidget = $(this).parent().find('.Count')
    let newCount = Number(countWidget.val()) - 1
    countWidget.val(newCount)
    if (newCount === 0) {
        disableDeleteButton(widget)
    }

    switch (widget.data('item-type')) {
        case "product":
            deleteProduct(widget.data('item-id') as number, shopName)
            break
        case "dish":
            $.each(widget.find('.product'), async function () {
                deleteProduct($(this).data('info').id as number, shopName)
            })
            break
    }

    function deleteProduct(id: number, shopName: string) {
        const pk = [id, shopName]

        const objectStore = getCartStore()

        objectStore.get(pk).onsuccess = async e => {
            // @ts-ignore
            let result = e.target.result as CartProduct
            const count = result.count = result.count - 1
            if (count === 0) {
                objectStore.delete(pk)
            } else {
                objectStore.put(result)
            }

            if (await isAuthenticated()) {
                ajaxDelete('Delete', pk)
            }
        }
    }
})

$('.Count').on('change', async function () {
    const widget = $(this).parents('.Item')
    const shopName = widget.find('.dd-selected-value').val() as string

    const countWidget = widget.find('.Count')
    const count = Number(countWidget.val())
    if (count < 0) {
        countWidget.val(0)
        disableDeleteButton(widget)
        return
    }

    switch (widget.data('item-type') as string) {
        case "product":
            const product = constructProduct(widget)
            product.count = count
            updateCount(product)
            break
        case "dish":
            $.each(widget.find('.product'), async function () {
                updateCount(constructConstituentProduct($(this), count, shopName))
            })
            break
    }

    function updateCount(product: CartProduct) {
        const pk = [product.id, product.shopName]

        const objectStore = getCartStore()

        objectStore.get(pk).onsuccess = async () => {
            if (count === 0) {
                objectStore.delete([product.id, product.shopName])
                disableDeleteButton(widget)
            } else {
                objectStore.put(product)
            }

            if (await isAuthenticated()) {
                ajaxPost(product, pk)
            }
        }
    }
})

const ddData = [
    {
        text: 'Аллея',
        value: 'alley',
        selected: false,
        imageSrc: '/img/shops/alley.png'
    },
    {
        text: 'Fixprice',
        value: 'fixPrice',
        selected: false,
        imageSrc: '/img/shops/fixPrice.png'
    },
    {
        text: 'Лента',
        value: 'lenta',
        selected: true,
        imageSrc: '/img/shops/lenta.png'
    }
]

// @ts-ignore
$('.Shop').ddslick({
    data: ddData,
    imagePosition: 'left',
    onSelected: (selected: object) => {
        //@ts-ignore
        const parent = $(selected.selectedItem).parents('.Item')
        const prices = parent.data('prices')
        parent.find('.Count').val(0)

        // @ts-ignore
        parent.find('.Price').text(prices[selected.selectedData.value])
    }
})

function constructConstituentProduct(productWidget: JQuery, count: number, shopName: string) {
    const product = productWidget.data('info') as CartProduct
    product.price = productWidget.data('prices')[shopName]
    product.shopName = shopName
    product.count = count
    return product
}

function constructProduct(widget: JQuery) {
    return new CartProduct(
        widget.data('item-id') as number,
        widget.find('.Name').text(),
        widget.find('.Price').text() as unknown as number,
        widget.find('.dd-selected-value').val() as string,
        widget.find('.Image').attr('src') as string,
        widget.find('.Weight').text() as unknown as number)
}

function activateDeleteButton(widget: JQuery) {
    widget.parent().find('.delete-from-cart').removeAttr('disabled')
}

function disableDeleteButton(widget: JQuery) {
    widget.find('.delete-from-cart').attr('disabled', 'disabled')
}

function getCartStore() {
    return db.transaction('cart', 'readwrite').objectStore('cart')
}

export async function isAuthenticated() {
    return $.get(`/Identity/Account/IsAuthenticated`, {}, (resp: boolean) => {
        return resp
    })
}
