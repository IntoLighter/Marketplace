"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var site_1 = require("./site");
$(function () {
    var transaction = site_1.db.transaction(['cart'], 'readwrite');
    var objectStore = transaction.objectStore('cart');
    var cursor = objectStore.openCursor();
    var products;
    cursor.onsuccess = function () {
        if (cursor.result === 0) {
            console.log("Db doesn't have cart products, trying to fetch from server");
            if ((0, site_1.isAuthenticated)()) {
                $.get('Areas/Cart/GetProducts', products, function () {
                    if (products.length === 0) {
                        console.log("Server also doesn't have cart products");
                        return;
                    }
                    else {
                        $.each(products, function (_, product) {
                            objectStore.add(product);
                        });
                        console.log("Added products to db");
                    }
                });
            }
        }
        else if ((0, site_1.isAuthenticated)()) {
            $.get('Areas/Cart/GetProducts', products, function () {
                if (products.length == 0) {
                    console.log("Server doesn't have products, uploading to it from db");
                    if (cursor) {
                        $.post('Areas/Cart/AddProduct', cursor.value);
                    }
                    cursor.continue();
                }
                console.log("Uploaded products to server");
            });
        }
        $.each(products, function (_, product) {
            // Load products to UI
        });
    };
});
