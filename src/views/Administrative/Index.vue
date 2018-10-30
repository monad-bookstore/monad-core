<template>
    <section>
        <div class="flexible-content h-100">
            <!-- Display side navigation -->
            <sidenav/>
            <!-- Page content -->
            <main>
                <router-view :key="$route.fullPath"></router-view>
            </main>
        </div>
    </section>
</template>
<script>
export default {
    components: {
        "sidenav": require('./components/sidenav/SidenavComponent.vue').default,
        "navigation-bar": require('./components/navbar/NavbarComponent.vue').default,
    }
}
</script>
<style lang="scss" scoped>

    .flexible-content {
        transition: padding-left 0.3s;
        padding-left: 240px;
    }

    main {
        height: 100%;
        background-color: #eeeeee;
    }

</style>
