<template>
<div class="container-fluid default-container adjust-navigator d-flex flex-column">
    <div class="row d-flex flex-grow-1 my-4">
        <div class="col-12">
            <div class="card default-styling">
                <div class="card-header">
                    <store-view-control/>
                </div>
                <div class="card-body p-0 position-relative">
                    <store-sidenav/>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- <div class="container-fluid default-container adjust-navigator">
    <div class="card default-styling">
        <div class="card-header">
            <store-view-control/>
        </div>
        <div class="card-body p-0">
            <div class="row">
                <div class="col-auto d-none d-lg-block">
                    <store-sidenav/>
                </div>
            </div>
        </div>
    </div>
</div> -->
</template>
<script>

    export default {

        mounted() {
            $(document).ready(function() {
                $('.carousel').carousel({
                    interval: false
                })
            });
        },

        components: {
            "store-sidenav": require('../components/navigation/StoreSidenavComponent.vue').default,
            "book-example": require('../components/misc/StoreGridBookComponent.vue').default,
            "store-view-control": require('../components/store/StoreViewControl.vue').default,
        }

    }

</script>
<style lang="scss" scoped>

    .toggle-navigator {
        position: relative;
        top: 0; left: 0;
        margin-top: 3rem;
        margin-left: 3rem;
    }

</style>
