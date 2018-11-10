<template>
<section>
    <div v-if="!reading_comments">
        <div class="row mt-2">
            <div class="col-auto d-flex justify-content-start">
                <img src="/images/book-cover-preview.png" height="400px" width="265px"/>
            </div>
            <div class="d-flex flex-grow-1 flex-column align-items-start justify-content-start">
                <div class="mb-auto">
                    <div class="book-author">
                        Antanas Škėma
                    </div>
                    <div class="book-title">
                        Balta drobulė
                    </div>
                </div>
                <div class="w-100">
                    <div class="d-flex flex-grow flex-row">
                        <div>
                            <div class="book-price">
                                Užsakymo kaina: 20.00&euro;
                            </div>
                            <button class="btn btn-md btn-outline-white m-0 mt-2 mr-2 waves-effect waves-light">
                                <i class="fas fa-clipboard-list white-text mr-2"></i> Daugiau knygų iš šio autoriaus
                            </button>
                            <button class="btn btn-md btn-outline-white m-0 mt-2 mr-2 waves-effect waves-light">
                                <i class="fab fa-wikipedia-w white-text mr-2"></i> Apie autorių
                            </button>
                            <button class="btn btn-md btn-white m-0 mt-2 mr-2 waves-effect waves-light" data-toggle="modal" data-target="#administrative">Administravimas</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="mt-4">
            <h4>Knygos aprašymas</h4>
            <div class="book-description">
                <p>Antanas Garšva dirba liftininku viename didžiausių Niujorko viešbučių. Jį slegia uniforma, bukinantis darbas, vienatvė,
                    kamuoja egzistenciniai klausimai, kūrybinės kančios ir, regis, jis tuoj, tuoj išprotės. „Baltoje drobulėje“ nėra aiškios intrigos,
                    vientiso pasakojimo, chronologijos, tai — pasąmonės srautas, įtraukiantis skaitytoją į Garšvos apmąstymus, įvykius, nutinkančius čia ir dabar, ir praeities atsiminimus. </p>
            </div>
            <h4>Užsakymo informacija</h4>
            <p class="mb-1">Pristatymo adresas: Adreso g. 17</p>
            <p>Užsakyta: 2018-10-10 12:43</p>
        </div>
    </div>
    <div v-else class="d-flex flex-column">
        <div class="mb-auto">
            <blockquote class="blockquote">
                <p class="mb-0">Skaičiau ir nieko nesupratau xdd</p>
                <footer class="blockquote-footer mb-3">Jonas Jonaitis</footer>
                <button class="btn btn-sm btn-outline-white m-0 mt-2 mr-2 waves-effect waves-light">
                    <i class="fas fa-pen white-text mr-2"></i> Redaguoti komentarą
                </button>
                <button class="btn btn-sm btn-outline-white m-0 mt-2 mr-2 waves-effect waves-light">
                    <i class="fas fa-trash-alt white-text mr-2"></i> Pašalinti komentarą
                </button>
            </blockquote>
            <blockquote class="blockquote">
                <p class="mb-0">Patiko. Rekomenduoju.</p>
                <footer class="blockquote-footer mb-3">Petras Petraitis</footer>
                <button class="btn btn-sm btn-outline-white m-0 mt-2 mr-2 waves-effect waves-light">
                    <i class="fas fa-pen white-text mr-2"></i> Redaguoti komentarą
                </button>
                <button class="btn btn-sm btn-outline-white m-0 mt-2 mr-2 waves-effect waves-light">
                    <i class="fas fa-trash-alt white-text mr-2"></i> Pašalinti komentarą
                </button>
            </blockquote>
        </div>
        <div class="align-self-end flex-grow">
            <div class="btn btn-md btn-white" @click="toggle_comment_reading()">
                Skaitytojų palikti komentarai
            </div>
        </div>
    </div>
</section>
</template>
<script>
export default {
    data() {
        return {
            reading_comments: false
        }
    },
    methods: {
        toggle_comment_reading() {
            this.reading_comments = !this.reading_comments
        }
    }
}
</script>

<style lang="scss" scoped>
.book-title {
    font-size: 14px;
}

.book-author {
    font-size: 21px;
}

.book-description {
    font-size: 13px;
}

.book-price {
    margin-top: 15px;
    font-size: 14px;
}
</style>
