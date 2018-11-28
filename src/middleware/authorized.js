export default function authorized({ next, router, axios, store }) {
    axios.get('/api/authentication/client').then(response => {
        store.commit('SetClient', response.data)
        return next()
    }).catch(e => {
        router.push({ name: "signin" })
    })
}