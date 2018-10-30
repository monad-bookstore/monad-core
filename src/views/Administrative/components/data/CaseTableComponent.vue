<template>
    <section>
        <table class="table table-hover btn-table">
            <thead class="elegant-color-dark white-text">
                <tr>
                    <th>#</th>
                    <th>Užsakymo ID.</th>
                    <th>Klientas</th>
                    <th>Sukūrimo data</th>
                    <th>Papildomai</th>
                </tr>
            </thead>
            <tbody>
                <case identifier="1" order-id="#000001" client="Vardenis Pavardenis"/>
                <case identifier="2" order-id="#000002" client="Vardenis Pavardenis"/>
                <case identifier="3" order-id="#000003" client="Vardenis Pavardenis"/>
            </tbody>
        </table>
    </section>
</template>
<script>
export default {
    components: {
        "case": require("./CaseTableItemComponent.vue").default
    }
}
</script>