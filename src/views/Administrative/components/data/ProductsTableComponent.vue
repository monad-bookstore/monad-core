<template>
    <section>
        <table class="table table-hover btn-table">
            <thead class="blue-grey lighten-4">
                <tr>
                    <th>#</th>
                    <th>Pavadinimas</th>
                    <th>Autorius</th>
                    <th>Kaina</th>
                    <th>Turimas kiekis</th>
                    <th>Pridėjimo data</th>
                    <th>Valdymas</th>
                </tr>
            </thead>
            <tbody>
                <product identifier="1" named="Knyga" author="Autorius" price="5.00" quantity="71"/>
                <product identifier="2" named="Knyga" author="Autorius" price="15.00" quantity="51"/>
                <product identifier="3" named="Knyga" author="Autorius" price="7.00" quantity="27"/>
                <product identifier="4" named="Knyga" author="Autorius" price="32.00" quantity="21"/>
            </tbody>
        </table>
    </section>
</template>
<script>
export default {
    components: {
        "product": require("./ProductTableItemComponent.vue").default
    }
}
</script>