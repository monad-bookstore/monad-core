<template>
<section>
    <div class="container adjusted d-flex wow fadeIn">
        <div class="row flex-fill m-4 rgba-black-view">
            <div class="col p-0 white-text py-3">
                <div class="row h-100 m-3">
                    <div class="col-12">
                        <h3 class="text-uppercase">Aktyvios bylos</h3>
                        <hr/>
                        <div class="d-flex flex-column">
                            <div class="">
                                <table class="table table-hover btn-table">
                                    <thead class="rgba-black-slight white-text">
                                        <tr>
                                            <th>#</th>
                                            <th>Tema</th>
                                            <th>Sukūrimo data</th>
                                            <th>Paskutinį kartą keista</th>
                                            <th>Būsena</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr @click="$router.push({ name: 'case' })">
                                            <td>2646412</td>
                                            <td>Knygų neatsiunčia jau 17 dienų</td>
                                            <td>2018-10-10 17:43</td>
                                            <td>2018-10-31 11:03</td>
                                            <td>Laukiama kliento atsakymo</td>
                                        </tr>
                                    </tbody>
                                </table>
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