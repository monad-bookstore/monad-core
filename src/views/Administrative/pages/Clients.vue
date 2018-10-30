<template>
    <section>
        <!-- Display fixed top navigation bar -->
        <navigation-bar>
            <template slot="additional-navbar-items">
            </template>
        </navigation-bar>
        <div class="m-5 p-5">
            <div class="card p-2">
                <client-datatable/>
            </div>
        </div>
    </section>
</template>
<script>
export default {
    components: {
        "client-datatable": require('../components/data/ClientsDataTableComponent.vue').default,
        "navigation-bar": require('../components/navbar/NavbarComponent.vue').default,
    }    
}
</script>