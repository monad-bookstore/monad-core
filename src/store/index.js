import Vue from 'vue'
import Vuex from 'vuex'
import createPersistedState from 'vuex-persistedstate'

import getters from "./getters"
import mutations from "./mutations"

Vue.use(Vuex)

const store = new Vuex.Store({
    state: {
        client: {
            ssid: null,
            data: {}
        },
        loaded: false
    },
    getters,
    mutations,
    plugins: [
        createPersistedState({
            key: "client",
            storage: window.sessionStorage
        })
    ]
})

export default store;