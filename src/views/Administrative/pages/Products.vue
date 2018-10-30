<template>
    <section>
        <!-- Display fixed top navigation bar -->
        <navigation-bar>
            <template slot="additional-navbar-items">
                <li class="nav-item">
                    <a class="nav-link" data-toggle="modal" data-target="#generic_modal">Pridėti naują prekę</a>
                </li>
            </template>
        </navigation-bar>
        <div class="m-5 p-5">
            <div class="card">
                <products-listing/>
            </div>
        </div>
        <!-- Product creation modal window -->
        <generic-modal title="Naujos prekės kūrimas">
            <template slot="body">
                <product-form/>
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
        "products-listing": require("../components/data/ProductsTableComponent.vue").default,
        "navigation-bar": require('../components/navbar/NavbarComponent.vue').default,
        "generic-modal": require('../components/modals/GenericModalComponent.vue').default,
        "product-form": require('../components/forms/ProductCreationFormComponent.vue').default,
    }
}
</script>