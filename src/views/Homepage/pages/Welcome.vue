<template>
    <section>
        <div class="text-center white-text mx-5 wow fadeIn raleway-font">
            <h1 class="mb-2">
               MONAD.LT
            </h1>
            <p>
                <strong>
                    Geriausia lietuviškų knygų ir publikacijų parduotuvė internete.
                </strong>
            </p>
            <a @click="$router.push({ name: 'store' })" class="btn btn-outline-white btn-lg waves-effect waves-light">
                Peržiūrėti knygas
            </a>
        </div>
    </section>
</template>
<script>
export default {
    mounted() {
        new WOW().init();
    },
}
</script>

<style lang="scss" scoped>

    .raleway-font {
        font-family: 'Raleway Light';
    }

</style>