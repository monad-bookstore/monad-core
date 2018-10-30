<template>
    <section>
        <div class="navy-blue-skin">
            <div class="side-nav background-image fixed">
                <li>
                    <div class="administrative-title white-text">
                        <h4 style="cursor: pointer;" @click="$router.push({ name: 'dashboard' })" class="flex-center pointer">Administravimas</h4>
                    </div>
                </li>
                <li>
                    <ul class="collapsible">
                        <li>
                            <a data-toggle="collapse" data-target="#product-subsystem" class="collapsible-header waves-effect arrow-r">
                                <i class="fa fa-chevron-right"></i> 
                                Prekių valdymas
                            </a>
                            <div class="collapse" id="product-subsystem">
                                <ul class="list-unstyled">
                                    <li><a href="#" @click="$router.push({ name: 'products' })" class="waves-effect">Prekės</a></li>
                                    <li><a href="#" @click="$router.push({ name: 'suppliers' })" class="waves-effect">Tiekėjai</a></li>
                                    <li><a href="#" @click="$router.push({ name: 'quality-control' })" class="waves-effect">Kokybės kontrolė</a></li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <a data-toggle="collapse" data-target="#client-subsystem" class="collapsible-header waves-effect arrow-r">
                                <i class="fa fa-chevron-right"></i> 
                                Klientų valdymas
                            </a>
                            <div class="collapse" id="client-subsystem">
                                <ul class="list-unstyled">
                                    <li><a href="#" @click="$router.push({ name: 'clients' })" class="waves-effect">Klientų sąrašas</a></li>
                                    <li><a href="#"  @click="$router.push({ name: 'orders' })" class="waves-effect">Užsakymai</a></li>
                                </ul>
                            </div>
                        </li>
                    </ul>
                </li>
                <div class="sidenav-bg mask-strong"></div>
            </div>
        </div>
    </section>
</template>
<script>
export default {
    components: {
        "content-view": require('components/content/View.vue').default,
    }
}
</script>
<style lang="scss">

    .administrative-title {
        height: 80px;
        border-bottom: 1px solid rgba(153,153,153,.3);
    }

</style>