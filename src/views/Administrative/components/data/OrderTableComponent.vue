<template>
    <section>
        <table class="table table-hover btn-table">
            <thead class="elegant-color-dark white-text">
                <tr>
                    <th>#</th>
                    <th>Užsakymo ID.</th>
                    <th>Užsakovas</th>
                    <th>Užsakymo kaina</th>
                    <th>Būsena</th>
                    <th>Sukūrimo data</th>
                    <th>Papildomai</th>
                </tr>
            </thead>
            <tbody>
                <order identifier="1" order-id="#000001" client="Vardenis Pavardenis" price-total="159.12" status="Įvykdyta"/>
                <order identifier="2" order-id="#000002" client="Vardenis Pavardenis" price-total="71.22"/>
                <order identifier="3" order-id="#000003" client="Vardenis Pavardenis" price-total="11.29"/>
            </tbody>
        </table>
    </section>
</template>
<script>
export default {
    components: {
        "order": require("./OrderTableItemComponent.vue").default
    }
}
</script>