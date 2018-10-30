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
                        <li class="nav-item active">
                            <a class="nav-link" href="#">Pagrindinis</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Parduotuvė</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Mano krepšelis</a>
                        </li>
                    </ul>
                    <!-- Links -->
                    <ul class="navbar-nav" v-if="$store.getters.isAuthenticated === false">
                        <li class="nav-item">
                            <a class="nav-link">Prisijungimas</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link">Registracija</a>
                        </li>
                    </ul>
                    <ul class="navbar-nav" v-else>
                        <li class="nav-item">
                            <a class="nav-link">Kliento meniu</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link">Nustatymai</a>
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