<template>
    <section>
        <!-- Display fixed top navigation bar -->
        <navigation-bar>
            <template slot="additional-navbar-items">
                <li class="nav-item">
                    <a class="nav-link" data-toggle="modal" data-target="#create_client">Pridėti naują vartotoją</a> 
                </li>               
            </template>
        </navigation-bar>
        <div class="m-5 p-5">
            <div class="card p-2">
                <client-datatable/>
            </div>
        </div>
        <!-- Client creation modal window -->
        <generic-modal title="Kliento pridėjimas" identifier="create_client">
            <template slot="body">
                <client-form/>
            </template>
            <template slot="footer">
                <button type="button" class="btn btn-elegant" data-dismiss="modal">
                    Patvirtinti
                </button>
                <button type="button" class="btn btn-primary" data-dismiss="modal">
                    Atšaukti
                </button>
            </template>
        </generic-modal>
        <!-- Client modification modal window -->
        <generic-modal title="Kliento redagavimas" identifier="edit_client">
            <template slot="body">
                <client-form/>
            </template>
            <template slot="footer">
                <button type="button" class="btn btn-elegant" data-dismiss="modal">
                    Patvirtinti
                </button>
                <button type="button" class="btn btn-primary" data-dismiss="modal">
                    Atšaukti
                </button>
            </template>
        </generic-modal>
        <!-- Client modification modal window -->
        <generic-modal title="Kliento užsakymai" identifier="client_orders">
            <template slot="body">
            </template>
            <template slot="footer">
                <button type="button" class="btn btn-primary" data-dismiss="modal">
                    Uždaryti
                </button>
            </template>
        </generic-modal>
    </section>
</template>
<script>
export default {
    components: {
        "generic-modal": require('../components/modals/GenericModalComponent.vue').default,
        "client-datatable": require('../components/data/ClientsDataTableComponent.vue').default,
        "client-form": require('../components/forms/ClientCreationFormComponent.vue').default,
        "navigation-bar": require('../components/navbar/NavbarComponent.vue').default,
        "order-view": require('../components/data/OrderTableComponent.vue').default,

    }    
}
</script>