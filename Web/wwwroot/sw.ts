const cacheName = `list-productsv1`
//
self.addEventListener('install', (e: any) => {
    // @ts-ignore
    e.waitUntil((async () => {
        const cache = await caches.open(cacheName)
        await cache.addAll([
            '/favicon.ico',
            '/favicon-16x16.png',
            '/favicon-32x32.png'
        ])
    })())
})

self.addEventListener(`fetch`, (e: any) => {
    e.respondWith((async () => {
        const r = await caches.match(e.request)
        if (r) {
            return r
        }
        const response = await fetch(e.request)
        const cache = await caches.open(cacheName)
        cache.put(e.request, response.clone())
        return response
    })())
})

self.addEventListener(`activate`, (e: any) => {
    // @ts-ignore
    e.waitUntil(caches.keys().then(keyList => Promise.all(keyList.map(key => {
        if (key === cacheName) return
        return caches.delete(key)
    }))))
})
