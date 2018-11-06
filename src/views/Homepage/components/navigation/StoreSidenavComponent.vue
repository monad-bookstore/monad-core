<template>
<div class="store-navigator absolute d-none d-lg-block overflow-y scrollbar scrollbar-white bordered-black  thin">
    <ul>
        <ul class="list-unstyled my-4">
            <li>
                <a href="#" class="waves-effect waves-light">
                    <i class="fas fa-clock mr-2"></i>
                    Naujienos
                </a>
            </li>
            <li>
                <a href="#" class="waves-effect waves-light">
                    <i class="fas fa-fire mr-2"></i>                
                    Populiariausios knygos
                </a>
            </li>
        </ul>
        <ul class="collapsible">
            <li>
                <a data-toggle="collapse" data-target="#book-simple" class="collapsible-header waves-effect arrow-r">
                    <i class="fa fa-chevron-right"></i>Grožinė literatūra
                </a>
                
                <div class="collapse" id="book-simple">
                    <ul class="list-unstyled">
                        <li><a href="#" class="waves-effect waves-light">Detektyvai, trileriai</a></li>
                        <li><a href="#" class="waves-effect waves-light">Klasika</a></li>
                        <li><a href="#" class="waves-effect waves-light">Lietuvių proza</a></li>
                        <li><a href="#" class="waves-effect waves-light">Fantastika</a></li>
                        <li><a href="#" class="waves-effect waves-light">Tikros istorijos</a></li>
                        <li><a href="#" class="waves-effect waves-light">Humoras ir komiksai</a></li>
                        <li><a href="#" class="waves-effect waves-light">Folkloras ir mitologija</a></li>
                        <li><a href="#" class="waves-effect waves-light">Istoriniai romanai</a></li>
                        <li><a href="#" class="waves-effect waves-light">Poezija</a></li>
                        <li><a href="#" class="waves-effect waves-light">Drama</a></li>
                        <li><a href="#" class="waves-effect waves-light">Esė</a></li>
                    </ul>
                </div>
            </li>
            <li>
                <a data-toggle="collapse" data-target="#book-simple-1" class="collapsible-header waves-effect arrow-r">
                    <i class="fa fa-chevron-right"></i>Istorinės knygos
                </a>

                <div class="collapse" id="book-simple-1">
                    <ul class="list-unstyled">
                        <li><a href="#" class="waves-effect waves-light">Detektyvai, trileriai</a></li>
                        <li><a href="#" class="waves-effect waves-light">Klasika</a></li>
                        <li><a href="#" class="waves-effect waves-light">Lietuvių proza</a></li>
                        <li><a href="#" class="waves-effect waves-light">Fantastika</a></li>
                        <li><a href="#" class="waves-effect waves-light">Tikros istorijos</a></li>
                        <li><a href="#" class="waves-effect waves-light">Humoras ir komiksai</a></li>
                        <li><a href="#" class="waves-effect waves-light">Folkloras ir mitologija</a></li>
                        <li><a href="#" class="waves-effect waves-light">Istoriniai romanai</a></li>
                        <li><a href="#" class="waves-effect waves-light">Poezija</a></li>
                        <li><a href="#" class="waves-effect waves-light">Drama</a></li>
                        <li><a href="#" class="waves-effect waves-light">Esė</a></li>
                    </ul>
                </div>
            </li>
        </ul>
    </ul>
</div>
</template>
<style lang="scss" scoped>
    @import "assets/scss/components/StoreCategoryNavigator.scss";    
</style>