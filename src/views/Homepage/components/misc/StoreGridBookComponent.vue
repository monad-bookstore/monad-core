<template>
<section>
    <div class="row mt-5" @click="$router.push({ name: 'overview' })">
        <div class="col-12 d-flex justify-content-center">
            <img src="/images/book-cover-preview.png" height="200px" width="132px"/>
        </div>
        <div class="col-12 text-center d-flex justify-content-center mt-2">
            <div class="book-author">
                Antanas Škėma
            </div>
       
        </div>
        <div class="col-12 d-flex justify-content-center">
            <div class="book-title">
                Balta drobulė (20.00&euro;)
            </div> 
        </div>
    </div>
</section>    
</template>
<style lang="scss" scoped>

    .book-title {
        font-size: 12px;
    }

    .book-author {
        font-size: 14px;
    }

</style>
