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

import router from './Administrative/routing';
Vue.use(VueRouter)

/* ------------------------------ ------------------------------ */
// Usable components.
/* ------------------------------ ------------------------------ */

Vue.component('application', require('./Administrative/Index.vue').default);

/* ------------------------------ ------------------------------ */

new Vue({
    el: '#vue-application',
    router
})