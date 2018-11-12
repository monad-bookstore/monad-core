<template>
    <section>
        <!-- Display fixed top navigation bar -->
        <navigation-bar>
            <template slot="additional-navbar-items">
                <li class="nav-item">
                    <a class="nav-link" data-toggle="modal" data-target="#generic_modal">Pridėti naują tiekėją</a>
                </li>
            </template>
        </navigation-bar>
        <div class="m-5 p-5">
            <div class="card">
                <suppliers-listing/>
            </div>
        </div>
        <!-- Product creation modal window -->
        <generic-modal title="Naujo tiekėjo pridėjimas">
            <template slot="body">
                <supplier-form/>
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
        <!-- Supplier modification modal window -->
        <generic-modal title="Tiekėjo redagavimas" identifier="edit_supplier">
            <template slot="body">
                <supplier-form/>
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
    </section>
</template>
<script>
export default {
    components: {
        "suppliers-listing": require("../components/data/SuppliersTableComponent.vue").default,
        "navigation-bar": require('../components/navbar/NavbarComponent.vue').default,
        "generic-modal": require('../components/modals/GenericModalComponent.vue').default,
        "supplier-form": require('../components/forms/SupplierCreationFormComponent.vue').default,
    }
}
</script>