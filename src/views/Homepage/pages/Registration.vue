<template>
    <section>
        <div class="container h-100">
            <div class="row align-items-center h-100 wow fadeIn">
                <div class="col-6 mx-auto login-form">
                    <div class="card py-2 text-center rounded-0 z-depth-3">
                        <div class="card-header text-uppercase">
                            <h3> Registracija </h3>
                        </div>
                        <div class="card-body py-1">
                            <!-- Email -->
                            <div class="md-form">
                                <input type="email" id="materialLoginFormEmail" class="form-control">
                                <label for="materialLoginFormEmail">El. paštas</label>
                            </div>
                            <!-- Password -->
                            <div class="md-form">
                                <input type="password" id="materialLoginFormPassword" class="form-control">
                                <label for="materialLoginFormPassword">Slaptažodis</label>
                            </div>
                            <!-- Repeat password -->
                            <div class="md-form">
                                <input type="password" id="materialLoginFormPassword" class="form-control">
                                <label for="materialLoginFormPassword">Pakartoti slaptažodį</label>
                            </div>
                            <!-- Name -->
                            <div class="md-form">
                                <input type="text" id="clientName" class="form-control">
                                <label for="clientName">Vardas</label>
                            </div>
                            <!-- Surname -->
                            <div class="md-form">
                                <input type="text" id="clientSurname" class="form-control">
                                <label for="clientSurname">Pavardė</label>
                            </div>
                            <button class="btn btn-outline-white btn-block mt-5 waves-effect rounded-0 z-depth-0" type="submit">Registruotis</button>
                            <small>Registruodamies jūs sutinkate su MONAD.LT privatumo politika ir bla bla bla.</small>
                            <hr>
                            <a @click="$router.push({ name: 'signin' })">Jau turite paskyrą? Prisijunkite.</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</template>
<script>
export default {
    mounted() {
        new WOW().init();
    },
}
</script>

<style lang="scss" scoped>

    .login-form 
    {
        color: white;

        a {
            color: inherit;
        }

        .card {
            background-color: rgba(0, 0, 0, 0.7);
            font-weight: 300;
        }

        .card-body, .card-header {
            background-color: transparent;
        }

        .card-header {
            font-family: "Raleway Light"
        }
    }

    input[type=date]:focus:not([readonly]), 
    input[type=datetime-local]:focus:not([readonly]), 
    input[type=email]:focus:not([readonly]), 
    input[type=number]:focus:not([readonly]),
    input[type=password]:focus:not([readonly]), 
    input[type=search-md]:focus:not([readonly]), 
    input[type=search]:focus:not([readonly]), 
    input[type=tel]:focus:not([readonly]), 
    input[type=text]:focus:not([readonly]), 
    input[type=time]:focus:not([readonly]), 
    input[type=url]:focus:not([readonly]), 
    textarea.md-textarea:focus:not([readonly]) {
        border-bottom: 1px solid white !important;
        box-shadow: 0 1px 0 0 white !important;
        color: white !important;
        +label {
            color: white !important;
        }
    }

    .md-form input[type=password],
    .md-form input[type=email],
    .md-form input[type=text] {
        border-bottom: 1px solid white !important;
        color: white !important;
        +label {
            color: white !important;
        }
    }

</style>