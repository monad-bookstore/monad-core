<template>
    <section>
        <table class="table table-hover btn-table">
            <thead class="blue-grey lighten-4">
                <tr>
                    <th>#</th>
                    <th>Pavadinimas</th>
                    <th>Įmonė</th>
                    <th>Direktorius</th>
                    <th>Tel. numeris</th>
                    <th>Pridėjimo data</th>
                    <th>Valdymas</th>
                </tr>
            </thead>
            <tbody>
                <supplier identifier="1" named="Knygų šalis" company="Knygų šalis UAB" director="Vardenis Pavardenis" phone="+3706XXXXXXX"/>
            </tbody>
        </table>
    </section>
</template>
<script>
export default {
    components: {
        "supplier": require("./SupplierTableItemComponent.vue").default
    }
}
</script>