<template>
    <div class="container adjusted m-auto">
        <div class="row d-flex justify-content-center my-5">
            <div class="col-sm-12 col-md-9 col-lg-6">
                <div class="card authorization p-sm-1 p-md-3">
                    <div class="card-header">
                        <h3 class="text-uppercase">Prisijungimas</h3>
                    </div>
                    <div class="card-body">
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
                        <div class="d-flex justify-content-end">
                            <div>
                                <!-- Remember me -->
                                <div class="custom-control custom-checkbox">
                                    <input type="checkbox" class="custom-control-input rounded-0" id="defaultLoginFormRemember">
                                    <label class="custom-control-label" for="defaultLoginFormRemember">Prisiminti mane</label>
                                </div>
                            </div>
                        </div>
                        <button class="btn btn-outline-white btn-block my-4 waves-effect rounded-0 z-depth-0" type="submit">Prisijungti</button>
                        <hr>
                        <a href="">Pamiršote slaptažodį?</a><br>
                        <a @click="$router.push({ name: 'registration' })">Naujo vartotojo registracija</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
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