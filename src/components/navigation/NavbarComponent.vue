<template>
    <nav class="navbar navbar-expand-lg navbar-monad scrolling-nav font raleway light">
        <div class="navbar-brand" @click="$router.push({ name: 'welcome' })">
            <strong>MONAD</strong> 
        </div>
    
        <div class="navbar-header d-lg-none">
            <button v-if="$store.getters.isAuthenticated" type="button" data-toggle="collapse" data-target="#navbar-content">
                <i class="fas fa-bars fa-2 white-text"></i>
            </button>
            <button class="m-0" type="button" @click="$router.push({ name: 'store' })">
                <i class="fas fa-shopping-cart fa-2 white-text"></i>
            </button>
            <section v-if="!$store.getters.isAuthenticated">
                <button type="button" @click="$router.push({ name: 'signin' })">
                    <i class="fas fa-user fa-2 white-text"></i>
                </button>
            </section>
            <section v-else>
                <a href="/administrative">
                    <button v-if="$store.getters.isAdministrator" class="m-0" type="button">
                        <i class="fas fa-unlock fa-2 white-text"></i>
                    </button>
                </a>
            </section>
        </div>
       
        <div class="collapse navbar-collapse" id="navbar-content">
            <ul class="navbar-nav mr-auto ml-sm-3">
                <li class="nav-item d-none d-lg-block">
                    <a class="nav-link waves-effect waves-light" @click="$router.push({ name: 'store' })"> Parduotuvė </a>
                </li>
                <section v-if="$store.getters.isAuthenticated">
                    <li class="nav-item">
                        <a class="nav-link waves-effect waves-light" @click="$router.push({ name: 'cart' })"> Pirkinių krepšelis </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link waves-effect waves-light" @click="$router.push({ name: 'orders' })"> Užsakymai </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link waves-effect waves-light" @click="$router.push({ name: 'cases' })"> Pagalbos centras </a>
                    </li>
                </section>
            </ul>
            <section v-if="!$store.getters.isAuthenticated">
                <ul class="navbar-nav d-none d-lg-block">
                    <li class="nav-item ml-sm-3">
                        <a class="nav-link waves-effect waves-light" @click="$router.push({ name: 'signin' })"> Prisijungimas </a>
                    </li>
                </ul>
                <ul class="navbar-nav d-none d-lg-block">
                    <li class="nav-item ml-sm-3">
                        <a class="nav-link waves-effect waves-light" @click="$router.push({ name: 'registration' })"> Registracija </a>
                    </li>
                </ul>
            </section>
            <section v-else>
                <ul class="navbar-nav ml-sm-3">
                    <li class="nav-item d-none d-lg-block" v-if="$store.getters.isAdministrator">
                        <a class="nav-link waves-effect waves-light" href="/administrative"> Administravimas </a>
                    </li>
                </ul>
            </section>
        </div>
    </nav>
</template>
<style lang="scss" scoped>


</style>
