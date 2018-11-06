<template>
<div class="btn-group">
    <a class="btn dropdown-toggle mr-4" type="button" data-toggle="dropdown" :data-target="`#${identifier}`">
        Basic dropdown
    </a>

    <div class="dropdown-menu">
        <a class="dropdown-item" href="#">Action</a>
        <a class="dropdown-item" href="#">Another action</a>
        <a class="dropdown-item" href="#">Something else here</a>
        <div class="dropdown-divider"></div>
        <a class="dropdown-item" href="#">Separated link</a>
    </div>
    <!-- Basic dropdown -->

    <!--Dropdown primary-->
    <div class="dropdown">

        <!--Trigger-->
        <a class="btn btn-primary dropdown-toggle" type="button" id="dropdownMenu2" data-toggle="dropdown"
      aria-haspopup="true" aria-expanded="false">Material dropdown</a>

        <!--Menu-->
        <div class="dropdown-menu dropdown-primary">
            <a class="dropdown-item" href="#">Action</a>
            <a class="dropdown-item" href="#">Another action</a>
            <a class="dropdown-item" href="#">Something else here</a>
            <a class="dropdown-item" href="#">Something else here</a>
        </div>
    </div>
</div>
</template>
<script>

    export default 
    {
        computed: {
            identifier: function() {
                return "dropdown-component-" + this._uid
            }
        }
    }

</script>
