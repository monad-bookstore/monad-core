<template>
<section>
    <div class="container-fluid adjusted m-auto wow fadeIn">
        <div class="row flex-fill h-100 m-4 rgba-black-view">
            <div class="col p-0 white-text py-3">
                <div class="row h-100 m-3">
                    <div class="col-12">
                        <h3 class="text-uppercase">Užsakymų istorija</h3>
                        <hr/>
                        <div class="row mt-3 d-flex flex-wrap flex-row align-items-start justify-content-start">
                            <div class="col-12">
                                <book-example/>
                            </div>
                            <div class="col-12 mt-5">
                                <book-example/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>    
</section>    
</template>
<script>
export default {
    data() {
        return {
            address_creator: false
        }
    },
    mounted() {
        new WOW().init();
    },
    methods: {
        address_creator_toggle: function() {
            this.address_creator = !this.address_creator;
        }
    },
    components: {
        "store-sidenav": require('../components/navigation/StoreSidenavComponent.vue').default,
        "book-example": require('../components/misc/OrderBookListingComponent.vue').default,
    }
}
</script>
<style lang="scss" scoped>

    .rgba-black-view {
        background-color: rgba(0, 0, 0, 0.7);
        hr {
            border-top: 1px solid rgba(153,153,153,.3);
        }
    }

    .container-fluid {
        &.adjusted {
            padding-top: 64px;
        }
    }

    .flex-fill {
        flex:1 1 auto;
    }

</style>