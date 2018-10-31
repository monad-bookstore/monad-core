<template>
    <section>
        <div class="container h-100">
            <div class="row align-items-center h-100 wow fadeIn">
                <div class="col-6 mx-auto login-form">
                    <div class="card py-2 text-center rounded-0 z-depth-3">
                        <div class="card-header text-uppercase">
                            <h3> Prisijungimas </h3>
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
                            <div class="d-flex justify-content-around">
                                <div>
                                    <!-- Remember me -->
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input rounded-0" id="defaultLoginFormRemember">
                                        <label class="custom-control-label" for="defaultLoginFormRemember">Prisiminti</label>
                                    </div>
                                </div>
                                <div>
                                    <!-- Forgot password -->
                                    <a href="">Pamiršote slaptažodį?</a>
                                </div>
                            </div>
                            <button class="btn btn-outline-white btn-block my-4 waves-effect rounded-0 z-depth-0" type="submit">Prisijungti</button>
                            <hr>
                            <a @click="$router.push({ name: 'registration' })">Naujo vartotojo registracija</a>
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
        
        input[type=checkbox]:checked + label
        { 
            &::before {
                background-color: black !important;
            }
        }

        .custom-control-input:focus ~ .custom-control-label::before {
            box-shadow:none !important;
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
    .md-form input[type=email] {
        border-bottom: 1px solid white !important;
        color: white !important;
        +label {
            color: white !important;
        }
    }

</style>