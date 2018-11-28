require('../bootstrap.js')

import Vue from 'vue'
import Vuex from 'vuex'
import VueRouter from 'vue-router'
import store from '~/store'

import { ClientService } from '../services/client.service'

/* ------------------------------ ------------------------------ */
// Vuex configuration.
/* ------------------------------ ------------------------------ */

Vue.use(Vuex)
Vue.prototype.$store = store

/* ------------------------------ ------------------------------ */
// VueRouter configuration and middleware implementation.
// https://markus.oberlehner.net/blog/implementing-a-simple-middleware-with-vue-router/
/* ------------------------------ ------------------------------ */
import router from './Homepage/routing';
Vue.use(VueRouter)

function nextFactory(context, middleware, index) {
    const subsequentMiddleware = middleware[index]
    if (!subsequentMiddleware)
        return context.next

    return (...parameters) => {
        context.next(...parameters)
        const nextMiddleware = nextFactory(context, middleware, index + 1)
        subsequentMiddleware({ ...context, next: nextMiddleware })
    };
}

router.beforeEach((to, from, next) => {

    if (to.meta.middleware) {
        const middleware = Array.isArray(to.meta.middleware) ? to.meta.middleware : [to.meta.middleware]
        const context = { from, next, router, to, axios, store }
        return middleware[0]({...context, next: nextFactory(context, middleware, 1)})
    }

    if (!!to.meta.titled) {
        document.title = to.meta.titled
    }

    return next()
})

/* ------------------------------ ------------------------------ */
// Axios request interceptor.
// Adding authentication key to header list.
/* ------------------------------ ------------------------------ */

axios.interceptors.request.use((config) => {
    const key = ClientService.getAuthorizationKey()
    if (key) {
        config.headers = { 'Authorization': 'Bearer ' + key };
    }
    
    return config
})

/* ------------------------------ ------------------------------ */
// Usable components.
/* ------------------------------ ------------------------------ */

Vue.component('application', require('./Homepage/Index.vue').default);

/* ------------------------------ ------------------------------ */

new Vue({
    el: '#vue-application',
    router,
    created() {
        this.$store.dispatch('PreloadClient')
    }
})