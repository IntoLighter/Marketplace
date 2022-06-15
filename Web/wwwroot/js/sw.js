const cacheName = `list-productsv1`;
self.addEventListener('install', (e) => {
    e.waitUntil((async () => {
        console.log(`Caching`);
        const cache = await caches.open(cacheName);
        await cache.add('kvak');
    })());
});
self.addEventListener(`fetch`, (e) => {
    e.respondWith((async () => {
        const r = await caches.match(e.request);
        console.log(`Fetching resource ${e.request.url}`);
        if (r) {
            return r;
        }
        const response = await fetch(e.request);
        const cache = await caches.open(cacheName);
        console.log(`Caching new resource: ${e.request.url}`);
        cache.put(e.request, response.clone());
        return response;
    }));
});
self.addEventListener(`activate`, (e) => {
    e.waitUntil(caches.keys().then(keyList => Promise.all(keyList.map(key => {
        if (key === cacheName)
            return;
        return caches.delete(key);
    }))));
});
//# sourceMappingURL=sw.js.map