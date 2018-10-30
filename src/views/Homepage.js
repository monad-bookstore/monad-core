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


/* ------------------------------ ------------------------------ */
// Usable components.
/* ------------------------------ ------------------------------ */

Vue.component('application', require('./Homepage/Index.vue').default);

/* ------------------------------ ------------------------------ */

new Vue({
    el: '#vue-application'
})