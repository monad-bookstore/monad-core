<template>
<section>
    <div class="container-fluid adjusted h-100 d-flex wow fadeIn">
        <div class="row flex-fill m-4 rgba-black-view">
            <div class="col p-0 white-text py-3">
                <div class="row h-100 m-3">
                    <div class="col-7">
                        <h3 class="text-uppercase">Prekių sąrašas</h3>
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
                    <div class="col-5">
                        <h3 class="text-uppercase">Užsakymas</h3>
                        <hr/>
                        <!-- Basic dropdown -->
                        <div class="my-2">
                            <button class="btn btn-outline-white btn-block dropdown-toggle text-left" type="button" data-toggle="dropdown" aria-haspopup="true"
                            aria-expanded="false">Pasirinkti pristatymo adresą</button>

                            <div class="dropdown-menu">
                                <a class="dropdown-item" href="#">Namų adresas</a>
                                <a class="dropdown-item" href="#">Darbo adresas</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="#">Pristatyti į nurodytą paštomatą</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" @click="address_creator_toggle()">Nurodyti naują adresą</a>
                            </div>
                        </div>
                        <!-- Basic dropdown -->
                        <div v-if="address_creator" class="my-2 wow fadeIn">
                            <!-- City -->
                            <div class="md-form">
                                <input type="text" id="address_city_form" class="form-control">
                                <label for="address_city_form">Miestas</label>
                            </div>
                            <!-- Street -->
                            <div class="md-form">
                                <input type="text" id="address_street_form" class="form-control">
                                <label for="address_street_form">Gatvė</label>
                            </div>
                            <!-- Namo numeris -->
                            <div class="md-form">
                                <input type="text" id="address_house_form" class="form-control">
                                <label for="address_house_form">Namo numeris</label>
                            </div>
                            <div class="my-2">
                                <button @click="address_creator_toggle()" class="btn btn-outline-white btn-block text-left" type="button">
                                    Pasirinkti iš jau sukurtų adresų
                                </button>
                            </div>
                        </div>
                        <!-- coupons -->
                        <div class="md-form">
                            <input type="text" id="coupons" class="form-control">
                            <label for="coupons">Nuolaidos kuponas</label>
                        </div>
                        <div class="my-5 text-left">
                            <h4>Užsakymo kaina: 40.00&euro;</h4>
                        </div>
                        <button class="btn btn-white btn-block" type="button">
                            Patvirtinti ir apmokėti
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

    .container-fluid {
        &.adjusted {
            padding-top: 64px;
        }
    }

    .flex-fill {
        flex:1 1 auto;
    }

</style>