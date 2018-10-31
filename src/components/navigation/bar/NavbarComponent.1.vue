<template>
    <section>
        <!--Navbar-->
        <nav class="navbar navbar-expand-lg navbar-dark rgba-black-strong fixed-top scrolling-navbar">
            <div class="container">
                <!-- Navbar brand -->
                <a class="navbar-brand" href="#">MONAD</a>

                <!-- Collapse button -->
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapse_navbar_element"
                    aria-controls="collapse_navbar_element" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <!-- Collapsible content -->
                <div class="collapse navbar-collapse" id="collapse_navbar_element">
                    <!-- Links -->
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item" :class="{ 'active': $route.name == 'welcome' }">
                            <a class="nav-link" @click="$router.push({ name: 'welcome' })">Pagrindinis</a>
                        </li>
                        <li class="nav-item" :class="{ 'active': $route.name == 'store' }">
                            <a class="nav-link" @click="$router.push({ name: 'store' })">Parduotuvė</a>
                        </li>
                        <li class="nav-item" :class="{ 'active': $route.name == 'cart' }" v-if="$store.getters.isAuthenticated === true">
                            <a class="nav-link" @click="$router.push({ name: 'cart' })">Mano krepšelis</a>
                        </li>
                    </ul>
                    <!-- Signin/Registration links -->
                    <ul class="navbar-nav" v-if="$store.getters.isAuthenticated === false">
                        <li class="nav-item" :class="{ 'active': $route.name == 'signin' }">
                            <a class="nav-link" @click="$router.push({ name: 'signin' })">Prisijungimas</a>
                        </li>
                        <li class="nav-item" :class="{ 'active': $route.name == 'registration' }">
                            <a class="nav-link" @click="$router.push({ name: 'registration' })">Registracija</a>
                        </li>
                    </ul>
                    <ul class="navbar-nav" v-else>
                        <!-- Dropdown -->
                        <li class="nav-item dropdown">
                            <a class="nav-link" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true"
                            aria-expanded="false"><u>Kliento meniu</u></a>
                            <div class="dropdown-menu dropdown-primary" aria-labelledby="navbarDropdownMenuLink">
                            <a class="dropdown-item" @click="$router.push({ name: 'orders' })">Užsakymai</a>
                            <a class="dropdown-item" @click="$router.push({ name: 'cases' })">Pagalbos centras</a>
                            <a class="dropdown-item" v-if="false">Pranešimai</a>
                            </div>
                        </li>

                        <li class="nav-item" v-if="false">
                            <a class="nav-link" @click="$router.push({ name: 'settings' })">Nustatymai</a>
                        </li>
                        <li v-if="$store.getters.isAdministrator === true" class="nav-item">
                            <a class="nav-link" href="/administrative">Administravimas</a>
                        </li>
                    </ul>
                </div>
                <!-- Collapsible content -->
            </div>
        </nav>
        <!--/.Navbar-->
    </section>
</template>