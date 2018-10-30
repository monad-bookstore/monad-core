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
    </section>
</template>
<script>
export default {
    components: {
        "order-view": require('../components/data/OrderTableComponent.vue').default,
        "navigation-bar": require('../components/navbar/NavbarComponent.vue').default,
    }
}
</script>
