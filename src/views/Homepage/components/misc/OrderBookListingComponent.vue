<template>
<section>
    <div class="row mt-2">
        <div class="col-1 d-flex justify-content-start">
            <img src="/images/book-cover-preview.png" height="200px" width="132px"/>
        </div>
            <div class="d-flex  ml-3 flex-grow-1 flex-column align-items-start justify-content-start">
                <div class="mb-auto">
                    <div class="book-author">
                        Antanas Škėma
                    </div>
                    <div class="book-title">
                        Balta drobulė
                    </div>
                    <div class="mt-2 book-status">
                        <span>Prekės būsena: Vykdoma</span><br>
                        <span>Užsakymo data: 2018-10-31 14:20</span>
                    </div>
                </div>
                <div class="w-100">
                    <div class="d-flex flex-grow flex-row">
                        <div>
                            <div class="book-price">
                                Kaina: 20.00&euro;
                            </div>
                            <button @click="$router.push({name: 'overview'})" class="btn btn-md btn-outline-white m-0 mt-2 mr-2 waves-effect waves-light">
                                <i class="fas fa-info-circle white-text mr-2"></i> Knygos apžvalga
                            </button>
                            <button class="btn btn-md btn-outline-white m-0 mt-2 mr-2 waves-effect waves-light">
                                <i class="fas fa-clipboard-list white-text mr-2"></i> Daugiau knygų iš šio autoriaus
                            </button>
                            <button class="btn btn-md btn-outline-white m-0 mt-2 mr-2 waves-effect waves-light">
                                <i class="fab fa-wikipedia-w white-text mr-2"></i> Apie autorių
                            </button>
                        </div>
                        <div class="ml-auto mt-auto">
                            <button @click="$router.push({name: 'contact'})" class="btn btn-md btn-outline-white m-0 mt-2 mr-2 waves-effect waves-light">
                                <i class="fas fa-file-signature white-text mr-2"></i> Susisiekti dėl užsakymo
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</section>
</template>

<style lang="scss" scoped>
.book-title {
    font-size: 14px;
}

.book-status {
    font-size: 14px;
}

.book-author {
    font-size: 21px;
}

.book-price {
    margin-top: 15px;
    font-size: 14px;
}
</style>
