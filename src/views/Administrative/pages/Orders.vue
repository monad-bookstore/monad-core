<template>
    <section>
        <navigation-bar/>
        <div class="m-5 p-5">
            <div class="card">
                <div class="card-header">
                    Užsakymų istorija
                </div>
                <div class="card-body">
                    <order-view/>
                </div>
            </div>
        </div>
        <!-- Product modification modal window -->
        <generic-modal title="Žinutė užsakovui" identifier="client_contact">
            <template slot="body">
                <!--Material textarea-->
                <div class="md-form">
                    <textarea type="text" id="form7" class="md-textarea form-control" rows="3"></textarea>
                    <label for="form7">Žinutė</label>
                </div>
            </template>
            <template slot="footer">
                <button type="button" class="btn btn-elegant" data-dismiss="modal">
                    Siųsti
                </button>
                <button type="button" class="btn btn-primary" data-dismiss="modal">
                    Atšaukti
                </button>
            </template>
        </generic-modal>
    </section>
</template>
<script>
export default {
    components: {
        "generic-modal": require('../components/modals/GenericModalComponent.vue').default,
        "order-view": require('../components/data/OrderTableComponent.vue').default,
        "navigation-bar": require('../components/navbar/NavbarComponent.vue').default,
    }
}
</script>
