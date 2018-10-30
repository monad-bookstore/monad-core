<template>
    <section>
        <!--Navbar-->
        <nav class="navbar navbar-dark fixed-top navbar-toggleable-md navbar-expand-lg scrolling-navbar double-nav elegant-color-dark">
            <!-- Links -->
            <ul class="nav navbar-nav nav-flex-icons">
                <li class="nav-item">
                    <a class="nav-link" href="/">Pagrindinis</a>
                </li>
                <slot name="additional-navbar-items"></slot>
            </ul>
            <!-- Links -->
        </nav>
        <!--/.Navbar-->
    </section>
</template>
<style lang="scss">
.double-nav {
    padding-left: 17rem;
}
</style>
