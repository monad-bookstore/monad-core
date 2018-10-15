<template>
    <section>
        <navigation-bar></navigation-bar>
        <content-view>
            <div class="container">
                
            </div>
        </content-view>
    </section>
</template>
<script>
export default {
    components: {
        "content-view": require('components/content/View.vue').default,
        "navigation-bar": require('components/navigation/bar/NavbarComponent.vue').default,
    }
}
</script>
