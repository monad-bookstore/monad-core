<template>
<div class="row h-100">
    <div class="col-12 d-none d-lg-block">
        <form class="form-inline float-right">
            <div class="md-form my-0">
                <input class="form-control m-0" type="text" placeholder="Paieška" aria-label="Paieška">
            </div>
        </form>
        <div class="btn-group mr-3">
            <div class="dropdown">
                <button class="btn btn-md btn-white dropdown-toggle" type="button" data-toggle="dropdown" data-target="sorting-options">
                    Rikiuoti pagal
                </button>

                <div class="dropdown-menu dropdown-primary">
                    <a class="dropdown-item" href="#">Kainą didėjančiai</a>
                    <a class="dropdown-item" href="#">Kainą mažėjančiai</a>
                    <a class="dropdown-item" href="#">Populiarumą</a>
                </div>
            </div>
        </div>
    </div>
    <div class="col-12 d-sm-block d-lg-none">
        <a class="float-left">
            <i class="fas fa-bars"></i>
        </a>
        <a class="float-right">
            <i class="fas fa-filter"></i>
        </a>
        <a class="float-right mr-2">
            <i class="fas fa-search"></i>
        </a>
    </div>
</div>
</template>
<style lang="scss" scoped>

    .fas {
        font-size: 1.25rem;
    }

</style>
