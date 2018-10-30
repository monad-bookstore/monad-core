import Vue from 'vue'
export default {
    data() {
        return {
            authorized: false
        }
    },
    created: function() {
        console.log("Client mixin created.")
    },
    methods: {
        isLoggedIn: function() {
            return this.authorized
        },
        authorize: function() {
            console.log("Clicked.")
            this.authorize = true
        }
    }
}