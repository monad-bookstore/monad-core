<template>
<section>
    <div class="container adjusted d-flex wow fadeIn">
        <div class="row flex-fill m-4 rgba-black-view">
            <div class="col p-0 white-text py-3">
                <div class="row h-100 m-3">
                    <div class="col-12">
                        <h3 class="text-uppercase">Knygų neatsiunčia jau 17 dienų</h3>
                        <hr/>
                        <div class="row">
                            <div class="col-12 mt-3">
                                <div class="chatbox-rgba p-2">
                                    <small>Jonas Jonaitis (2018-10-10 17:43)</small><br/>
                                    <p class="m-0 ml-2">Sveiki, savo užsakymo negaunu jau 17 dienų, ką daryt?</p>
                                </div>
                            </div>
                            <div class="col-12 mt-3">
                                 <div class="chatbox-rgba p-2">
                                    <small>Prekių kokybės kontrolės darbuotojas (2018-10-31 11:03)</small><br/>
                                    <p class="m-0 ml-2">Bandymas.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-12">
                        <div class="my-1">
                            <!--Material textarea-->
                            <div class="md-form">
                                <textarea type="text" id="form7" class="md-textarea form-control" rows="3"></textarea>
                                <label for="form7">Naujas komentaras</label>
                            </div>
                        </div>
                        <button type="button" class="btn btn-lg btn-block btn-white">
                            Patvirtinti
                        </button>
                        <button type="button" class="btn btn-lg btn-block btn-danger mt-2">
                            Uždaryti bylą
                        </button>
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
        "book-example": require('../components/misc/CartBookListingComponent.vue').default,
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

    .chatbox-rgba {
        background-color: rgba(255, 255, 255, .1)
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