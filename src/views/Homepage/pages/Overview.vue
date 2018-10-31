<template>
<section>
    <div class="container-fluid adjusted m-auto wow fadeIn ">
        <div class="row flex-fill h-100 m-4 rgba-black-view">
            <div class="col p-0 white-text py-3">
                <div class="row h-100 m-3">
                    <div class="col-12">
                        <h3 class="text-uppercase">Knygos apžvalga</h3>
                        <hr/>
                        <book-example/>
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
        "book-example": require('../components/misc/BookOverviewComponent.vue').default,
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