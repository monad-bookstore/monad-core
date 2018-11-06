<template>
    <section>
        <navigator/>
        <wrapper>
            <transition name="fade" mode="out-in">
                <router-view :key="$route.name + ($route.params.id || null)"></router-view>
            </transition>
        </wrapper>
        <div class="fixed-bottom" v-if="$route.name == 'welcome'">
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
            "wrapper": require('components/content/View.vue').default,
            "navigator": require('components/navigation/NavbarComponent.vue').default,
        }
    }

</script>
<style lang="scss">

    .fade-enter-active,
    .fade-leave-active {
        transition-duration: 0.3s;
        transition-property: opacity;
        transition-timing-function: ease;
    }

    .fade-enter,
    .fade-leave-active {
        opacity: 0
    }

</style>
