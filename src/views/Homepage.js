require('../bootstrap.js')
import Vue from 'vue'

Vue.component('application', require('./Homepage/Index.vue').default);

new Vue({
    el: '#vue-application',
    created() {
        console.log("Yes.")
    }
})