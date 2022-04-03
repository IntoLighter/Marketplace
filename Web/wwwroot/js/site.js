"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.db = exports.isAuthenticated = exports.CartProduct = void 0;
var CartProduct = /** @class */ (function () {
    function CartProduct(name, price, count, shopName) {
        this.name = name;
        this.price = price;
        this.count = count;
        this.shopName = shopName;
    }
    return CartProduct;
}());
exports.CartProduct = CartProduct;
function isAuthenticated() {
    $.get('Areas/Identity/Account/IsAuthenticated', {}, function (resp) {
        if (resp) {
            return true;
        }
    });
    return false;
}
exports.isAuthenticated = isAuthenticated;
var openRequest = window.indexedDB.open('marketplace', 1);
openRequest.onsuccess = function () {
    console.log('Db opened successfully');
    exports.db = openRequest.result;
};
openRequest.onerror = function () { return console.log('Db failed to open'); };
openRequest.onupgradeneeded = function (e) {
    // @ts-ignore
    exports.db = e.target.result;
    var objectStore = exports.db.createObjectStore('Cart', { keyPath: ['Name', 'ShopName'], autoIncrement: true });
    objectStore.createIndex('Product', 'Product', { unique: false });
    objectStore.createIndex('Count', 'Count', { unique: false });
    console.log('Db set up');
};
var ddData = [
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
];
$('#Shop').ddsclick({
    data: ddData,
    width: 100,
    imagePosition: 'left'
});
$('.add-to-cart').on('click', function () {
    var parent = $(this).parent();
    var name = parent.find('#Name').text();
    var shopName = parent.find('#Shop').val();
    var count = parent.find('#Count').text();
    var product = new CartProduct(name, parent.find('#Price').text(), count, shopName);
    $.get('Areas/Identity/Account/IsAuthenticated', {}, function (resp) {
        if (resp) {
            $.post('Areas/Cart/AddProduct', product, function () {
                console.log("Sent {".concat(name, ", ").concat(shopName, "}  to server"));
            }).fail(function () { return console.log("Failed to send {".concat(name, ", ").concat(shopName, "} to server")); });
        }
    });
    var transaction = exports.db.transaction(['Cart'], 'readwrite');
    var objectStore = exports.db.objectStore('Cart');
    var cursorRequest = objectStore.openCursor();
    transaction.onerror = function () { return console.log('Transaction to add product failed'); };
    cursorRequest.onsuccess = function (e) {
        var cursor = e.target.result;
        if (cursor) {
            if (cursor.primaryKey.name === name && cursor.primaryKey.shopName === shopName) {
                cursor.value.count = count;
                cursor.update(cursor.value);
                console.log("Found {".concat(name, ", ").concat(shopName, "} in db and updated"));
                return;
            }
            cursor.continue();
        }
    };
    objectStore.add(product);
    console.log("Added {".concat(name, ", ").concat(shopName, "} in db"));
});
$('.delete-from-cart').on('click', function () {
    var parent = $(this).parent();
    var name = parent.find('#Name').text();
    var shopName = parent.find('#Shop').val();
    var transaction = exports.db.transaction(['cart'], 'readwrite');
    var objectStore = transaction.objectStore('cart');
    objectStore.delete([name, shopName]);
    transaction.oncomplete = function () {
        parent.remove();
        if (isAuthenticated()) {
            $.post('Areas/Cart/DeleteProduct', { name: name, shopName: shopName }, function () { return console.log("Sent {".concat(name, ", ").concat(shopName, "} to server")); })
                .fail(function () { return console.log("Failed to send {".concat(name, ", ").concat(shopName, "} to server")); });
        }
    };
    transaction.onerror = function () { return console.log('Transaction to delete product failed'); };
});
