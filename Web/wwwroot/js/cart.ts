import {CartProduct, isAuthenticated, db} from "./site";

$(function () {
        const transaction = db.transaction(['cart'], 'readwrite')
        const objectStore = transaction.objectStore('cart')
        const cursor = objectStore.openCursor()
        let products

        cursor.onsuccess = () => {
            if (cursor.result === 0) {
                console.log(`Db doesn't have cart products, trying to fetch from server`)
                if (isAuthenticated()) {
                    $.get('Areas/Cart/GetProducts', products, () => {
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
            
            $.each(products, (_, product) => {
                // Load products to UI
            })
        }
    }
)
