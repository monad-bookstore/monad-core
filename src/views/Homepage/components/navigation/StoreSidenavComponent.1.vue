<template>
<div class="side-nav relative z-depth-0 text-left">
    <li>
        <ul class="collapsible">
            <li>
                <a data-toggle="collapse" data-target="#book-simple" class="collapsible-header waves-effect arrow-r">
                                <i class="fa fa-chevron-right"></i> 
                                Grožinė literatūra
                            </a>
                <div class="collapse" id="book-simple">
                    <ul class="list-unstyled">
                        <li><a href="#" class="waves-effect">Detektyvai, trileriai</a></li>
                        <li><a href="#" class="waves-effect">Klasika</a></li>
                        <li><a href="#" class="waves-effect">Lietuvių proza</a></li>
                        <li><a href="#" class="waves-effect">Fantastika</a></li>
                        <li><a href="#" class="waves-effect">Tikros istorijos</a></li>
                        <li><a href="#" class="waves-effect">Humoras ir komiksai</a></li>
                        <li><a href="#" class="waves-effect">Folkloras ir mitologija</a></li>
                        <li><a href="#" class="waves-effect">Istoriniai romanai</a></li>
                        <li><a href="#" class="waves-effect">Poezija</a></li>
                        <li><a href="#" class="waves-effect">Drama</a></li>
                        <li><a href="#" class="waves-effect">Esė</a></li>
                    </ul>
                </div>
            </li>
            <li>
                <a data-toggle="collapse" data-target="#book-history" class="collapsible-header waves-effect arrow-r">
                                <i class="fa fa-chevron-right"></i> 
                                Istorija
                            </a>
                <div class="collapse" id="book-history">
                    <ul class="list-unstyled">
                        <li><a href="#" class="waves-effect">Faktai ir įdomybės</a></li>
                        <li><a href="#" class="waves-effect">Holokaustas</a></li>
                        <li><a href="#" class="waves-effect">Istorijos žinynai</a></li>
                        <li><a href="#" class="waves-effect">Istoriniai romanai</a></li>
                        <li><a href="#" class="waves-effect">Istorinės asmenybės</a></li>
                        <li><a href="#" class="waves-effect">Karo istorija</a></li>
                        <li><a href="#" class="waves-effect">Kriminalai</a></li>
                        <li><a href="#" class="waves-effect">Lietuvos istorija</a></li>
                    </ul>
                </div>
            </li>
        </ul>

    </li>
</div>
</template>
<style lang="scss" scoped>
    @import "assets/scss/components/StoreCategoryNavigator.scss";    
</style>