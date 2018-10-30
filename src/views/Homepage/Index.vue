<template>
    <section>
        <navigation-bar></navigation-bar>
        <content-view>
            <div class="container-fluid">
                Ar.
            </div>
        </content-view>
        <div class="fixed-bottom">
            <div class="btn-group dropright">
                <div v-if="$store.getters.isAuthenticated === false" class="btn-floating btn-lg white" @click="authorize()">
                    <i class="fa fa-user black-text"></i>
                </div>
                <div v-else class="btn-floating btn-lg white" @click="logout()">
                    <i class="fas fa-sign-out-alt black-text"></i>
                </div>
            </div>
        </div>
    </section>
</template>
<script>
export default {
    methods: {
        authorize: function() {
            this.$store.commit("AuthorizeClient", "Administrator-PrototypeTest")
        },
        logout: function() {
            this.$store.commit("LogoutClient")
        }
    },
    components: {
        "content-view": require('components/content/View.vue').default,
        "navigation-bar": require('components/navigation/bar/NavbarComponent.vue').default,
    }
}
</script>