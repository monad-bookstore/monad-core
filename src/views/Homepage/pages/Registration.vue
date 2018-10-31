<template>
    <div class="container adjusted m-auto">
        <div class="row d-flex justify-content-center my-5">
            <div class="col-sm-12 col-md-9 col-lg-6">
                <div class="card authorization p-sm-1 p-md-3">
                    <div class="card-header">
                        <h3 class="text-uppercase">Registracija</h3>
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
</template>
<script>
export default {
    mounted() {
        new WOW().init();
    },
}
</script>
