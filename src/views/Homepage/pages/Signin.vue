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