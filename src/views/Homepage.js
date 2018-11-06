require('../bootstrap.js')

import Vue from 'vue'
import Vuex from 'vuex'
import VueRouter from 'vue-router'

/* ------------------------------ ------------------------------ */
// Vuex configuration.
/* ------------------------------ ------------------------------ */

Vue.use(Vuex)
Vue.prototype.$store = require('~/store').default


/* ------------------------------ ------------------------------ */
// VueRouter configuration.
/* ------------------------------ ------------------------------ */
import router from './Homepage/routing';
Vue.use(VueRouter)

router.beforeEach((to, from, next) => {
    if (!!to.meta.titled) {
        document.title = to.meta.titled
    }
    next()
})


/* ------------------------------ ------------------------------ */
// Usable components.
/* ------------------------------ ------------------------------ */

Vue.component('application', require('./Homepage/Index.vue').default);

/* ------------------------------ ------------------------------ */

new Vue({
    el: '#vue-application',
    router
})