<template>
<section>
    <div class="container-fluid adjusted m-auto wow fadeIn">
        <div class="row flex-fill h-100 m-4 rgba-black-view">
            <div class="col-auto p-0 d-none d-lg-block">
                <store-sidenav/>
            </div>
            <div class="col p-0 white-text py-3">
                <div class="row px-3 d-flex align-items-center">
                    <div class="col col-md-6 col-sm-6">
                        <button class="btn btn-outline-white btn-sm dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Išdėstymo tvarka</button>

                    <div class="dropdown-menu">
                        <a class="dropdown-item" href="#">Rikiuoti pagal kainą mažėjančiai</a>
                        <a class="dropdown-item" href="#">Rikiuoti pagal kainą didėjančiai</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="#">Rikiuoti pagal datą mažėjančiai</a>
                        <a class="dropdown-item" href="#">Rikiuoti pagal datą didėjančiai</a>                        
                    </div>
                    </div>
                    <div class="col col-md-6 col-sm-6">
                        <form class="form-inline float-right">
                            <div class="md-form my-0">
                                <input class="form-control mr-sm-2" type="text" placeholder="Paieška" aria-label="Paieška">
                            </div>
                            <button class="btn btn-outline-white btn-sm my-2 my-sm-0 ml-3" type="submit">Ieškoti</button>
                        </form>
                    </div>
                </div>
                <hr/>
                <div class="row d-flex flex-wrap flex-row align-items-start justify-content-start">
                    <div class="col-2">
                        <book-example/>
                    </div>
                    <div class="col-2">
                        <book-example/>
                    </div>
                    <div class="col-2">
                        <book-example/>
                    </div>
                    <div class="col-2">
                        <book-example/>
                    </div>
                    <div class="col-2">
                        <book-example/>
                    </div>
                    <div class="col-2">
                        <book-example/>
                    </div>
                    <div class="col-2">
                        <book-example/>
                    </div>
                    <div class="col-2">
                        <book-example/>
                    </div>
                    <div class="col-2">
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
    mounted() {
        new WOW().init();
    },
    components: {
        "store-sidenav": require('../components/navigation/StoreSidenavComponent.vue').default,
        "book-example": require('../components/misc/StoreGridBookComponent.vue').default,
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
