<template>
    <div class="container adjusted m-auto">
        <div class="row d-flex justify-content-center my-5">
            <div class="col-sm-12 col-md-9 col-lg-6">
                <div class="card authorization p-sm-1 p-md-3">
                    <div class="card-header">
                        <h3 class="text-uppercase">Prisijungimas</h3>
                    </div>
                    <div class="card-body">
                        <transition name="fade" mode="out-in">
                            <div v-if="error.present">
                                {{ error.message }}
                            </div>
                        </transition>
                        <!-- Username -->
                        <div class="md-form">
                            <input type="text" id="username" class="form-control" v-model="username">
                            <label for="username">Prisijungimo vardas</label>
                        </div>
                        <!-- Password -->
                        <div class="md-form">
                            <input type="password" id="password" class="form-control" v-model="password">
                            <label for="password">Slaptažodis</label>
                        </div>
                        <button class="btn btn-white btn-block my-4 waves-effect rounded-0 z-depth-0" @click="submit">
                            <span v-if="loading">
                                <i class="fas fa-spinner"></i>
                            </span>
                            <span v-else>
                                Prisijungti
                            </span>
                        </button>
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
import { ClientService } from "~/services/client.service"
export default {
    data: () => ({
        loading: false,
        username: "",
        password: "",
        error: {
            present: false,
            message: ""
        }
    }),
    methods: {
        submit() {
            this.loading = true
            axios.post('/api/authentication/validate', { 
                username: this.username, 
                password: this.password 
            })
            .then((response) => {
                ClientService.setAuthorizationKey(response.data.authorizationKey)
                this.$store.commit("SetClient", response.data)
                this.$router.push({ name: "welcome" })
                this.loading = false
            })
            .catch((error) => {
                this.error.present = true
                this.error.message = error.response.data.message
                this.loading = false
            })
        }
    }
}
</script>
