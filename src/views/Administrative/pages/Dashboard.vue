<template>
    <section>
         <!-- Display fixed top navigation bar -->
        <navigation-bar/>
            <div class="m-5 p-5">
                <div class="row">
                    <!-- Pardavimų skaičiuoklė -->
                    <div class="mb-r col-md-6 col-xl-3">
                        <div class="cascading-admin-card card card-cascade">
                            <div class="admin-up">
                                <i class="primary-color fas fa-money-bill"></i>
                                <div class="data">
                                    <p>Pardavimai</p>
                                    <h4><strong>2452.41&euro;</strong></h4>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="progress">
                                    <div aria-valuemax="100" aria-valuemin="0" aria-valuenow="7" role="progressbar" class="progress-bar bg-primary" style="width: 7%;"></div>
                                </div>
                                <p class="card-text">Geriau nei praeitą savaitę (7%)</p>
                            </div>
                        </div>
                    </div>
                    <!-- Naujų klientų skaičiuoklė -->
                    <div class="mb-r col-md-6 col-xl-3">
                        <div class="cascading-admin-card card card-cascade">
                            <div class="admin-up">
                                <i class="warning-color fas fa-chart-line"></i>
                                <div class="data">
                                    <p>Nauji klientai</p>
                                    <h4><strong>745</strong></h4>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="progress">
                                    <div aria-valuemax="100" aria-valuemin="0" aria-valuenow="14" role="progressbar" class="progress-bar bg-primary" style="width: 14%;"></div>
                                </div>
                                <p class="card-text">Geriau nei praeitą savaitę (14%)</p>
                            </div>
                        </div>
                    </div>
                    <!-- Apsilankymų skaičiuoklė -->
                    <div class="mb-r col-md-6 col-xl-3">
                        <div class="cascading-admin-card card card-cascade">
                            <div class="admin-up">
                                <i class="light-blue lighten-1 fas fa-chart-pie"></i>
                                <div class="data">
                                    <p>Apsilankymai (mėn.)</p>
                                    <h4><strong>14753</strong></h4>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="progress">
                                    <div aria-valuemax="100" aria-valuemin="0" aria-valuenow="34" role="progressbar" class="progress-bar bg-primary" style="width: 34%;"></div>
                                </div>
                                <p class="card-text">Geriau nei praeitą savaitę (34%)</p>
                            </div>
                        </div>
                    </div>  
                    <!-- Unikalių apsilankymų skaičiuoklė -->
                    <div class="mb-r col-md-6 col-xl-3">
                        <div class="cascading-admin-card card card-cascade">
                            <div class="admin-up">
                                <i class="red accent-2 fas fa-chart-bar"></i>
                                <div class="data">
                                    <p>Unikalūs apsilankymai (mėn.)</p>
                                    <h4><strong>7541</strong></h4>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="progress">
                                    <div aria-valuemax="100" aria-valuemin="0" aria-valuenow="28" role="progressbar" class="progress-bar bg-primary" style="width: 28%;"></div>
                                </div>
                                <p class="card-text">Geriau nei praeitą savaitę (28%)</p>
                            </div>
                        </div>
                    </div>               
                </div>

                <div class="row">
                    <div class="mb-4 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <table class="table table-hover">
                                    <thead class="blue-grey lighten-4">
                                        <tr>
                                            <th>#</th>
                                            <th>Lorem</th>
                                            <th>Ipsum</th>
                                            <th>Dolor</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <th scope="row">1</th>
                                            <td>Cell 1</td>
                                            <td>Cell 2</td>
                                            <td>Cell 3</td>
                                        </tr>
                                        <tr>
                                            <th scope="row">2</th>
                                            <td>Cell 4</td>
                                            <td>Cell 5</td>
                                            <td>Cell 6</td>
                                        </tr>
                                        <tr>
                                            <th scope="row">3</th>
                                            <td>Cell 7</td>
                                            <td>Cell 8</td>
                                            <td>Cell 9</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div data-v-11b18fb6="" class="mb-4 col-md-6">
                        <div data-v-c9cc8e1e="" class="card" data-v-11b18fb6="">
                            <div class="card-body" data-v-c9cc8e1e="">
                                <table class="table table-hover">
                                    <thead class="blue lighten-4">
                                        <tr>
                                            <th>#</th>
                                            <th>Lorem</th>
                                            <th>Ipsum</th>
                                            <th>Dolor</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <th scope="row">1</th>
                                            <td>Cell 1</td>
                                            <td>Cell 2</td>
                                            <td>Cell 3</td>
                                        </tr>
                                        <tr>
                                            <th scope="row">2</th>
                                            <td>Cell 4</td>
                                            <td>Cell 5</td>
                                            <td>Cell 6</td>
                                        </tr>
                                        <tr>
                                            <th scope="row">3</th>
                                            <td>Cell 7</td>
                                            <td>Cell 8</td>
                                            <td>Cell 9</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </section>
</template>
<script>
export default {
    components: {
        "navigation-bar": require('../components/navbar/NavbarComponent.vue').default,
    }
}
</script>

<style lang="scss" scoped>

    .cascading-admin-card {
        margin: 20px 0;
    }

    .cascading-admin-card .admin-up {
        margin-left: 4%;
        margin-right: 4%;
        margin-top: -20px;
    }

    .cascading-admin-card .admin-up .fas {
        box-shadow: 0 2px 9px 0 rgba(0,0,0,.2), 0 2px 13px 0 rgba(0,0,0,.19);
        padding: 1.7rem;
        font-size: 2rem;
        color: #fff;
        text-align: left;
        margin-right: 1rem;
        border-radius: 3px;
    }

    .cascading-admin-card .admin-up .data {
        float: right;
        margin-top: 2rem;
        text-align: right;
    }

    .card .card-body .card-text {
        font-size: .9rem;
        font-weight: 400;
    }

</style>
