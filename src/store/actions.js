import axios from "axios";

export default {
    PreloadClient({ commit }) {
        axios.get('/api/authentication/client').then(response => {
            commit('SetClient', response.data)
        })
    }
}