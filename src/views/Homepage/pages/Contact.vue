<template>
    <div class="container adjusted wow fadeIn m-auto">
        <div class="row flex-fill h-100 m-4 rgba-black-view">
            <div class="col p-0 white-text py-3">
                <div class="row m-3">
                    <div class="col-12">
                        <h3 class="text-uppercase">Susisiekimas</h3>
                        <hr/>
                        <div class="d-flex flex-column">
                            <div class="my-2 flex-grow">
                                <h5>Užsakymo ID: #000001</h5>
                            </div>
                            <!-- Basic dropdown -->
                            <div class="my-2">
                                <button class="btn btn-outline-white btn-block text-left" type="button" data-toggle="dropdown" aria-haspopup="true"
                                    aria-expanded="false">Pasirinkite iškilusios problemos kategoriją</button>

                                <div class="dropdown-menu">
                                    <a class="dropdown-item" href="#">Gauta prekė sugadinta</a>
                                    <a class="dropdown-item" href="#">Gauta prekė neatitiko užsakymo</a>
                                    <a class="dropdown-item" href="#">Prekė nepristatyta</a>
                                    <div class="dropdown-divider"></div>
                                    <a class="dropdown-item" href="#">Kita</a>
                                </div>
                            </div>
                            <div class="my-2">
                                <!-- Tema -->
                                <div class="md-form mb-3">
                                    <input type="text" id="subject" class="form-control">
                                    <label for="subject">Tema</label>
                                </div>
                                <!--Material textarea-->
                                <div class="md-form">
                                    <textarea type="text" id="form7" class="md-textarea form-control" rows="3"></textarea>
                                    <label for="form7">Problemos aprašymas</label>
                                </div>
                            </div>
                            <div class="my-2">
                                <h6 class="mb-0">Prisekite failus, kurie padėtų išspręsti Jūsų problemą:</h6>
                                <small>Palaikomi formatai: jpeg, png, docx.</small>
                                <!--Material textarea-->
                                <div class="input-group my-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text" id="inputGroupFileAddon01">Įkelti</span>
                                    </div>
                                    <div class="custom-file">
                                        <input type="file" class="custom-file-input" id="inputGroupFile01" aria-describedby="inputGroupFileAddon01">
                                        <label class="custom-file-label" for="inputGroupFile01">Pasirinkti failą</label>
                                    </div>
                                </div>
                            </div>
                            <div class="mt-4">
                                <button class="btn btn-lg btn-block btn-white">
                                    Patvirtinti
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>  
</template>
<style lang="scss" scoped>

    .rgba-black-view {
        background-color: rgba(0, 0, 0, 0.7);
        hr {
            border-top: 1px solid rgba(153,153,153,.3);
        }
    }

    .container {
        &.adjusted {
            padding-top: 64px;
        }
    }

    .flex-fill {
        flex:1 1 auto;
    }

</style>