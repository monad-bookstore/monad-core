<template>
    <section>
        <!-- Display fixed top navigation bar -->
        <navigation-bar>
            
        </navigation-bar>
        <div class="m-5 p-5">
            <div class="card mb-4">
                <div class="card-header">
                    Naujausios bylos
                </div>
                <div class="card-body">
                    <newest-case-listing/>
                </div>
            </div>
             <div class="card mb-4">
                <div class="card-header">
                    Uždarytos bylos
                </div>
                <div class="card-body">
                    <newest-case-listing/>
                </div>
            </div>
        </div>
        <!-- Product creation modal window -->
        <generic-modal identifier="assign-workers" title="Darbuotojų priskyrimas">
            <template slot="body">
               
            </template>
            <template slot="footer">
                <button type="button" class="btn btn-elegant" data-dismiss="modal">
                    Patvirtinti
                </button>
                <button type="button" class="btn btn-primary" data-dismiss="modal">
                    Atšaukti
                </button>
            </template>
        </generic-modal>
    </section>
</template>
<script>
export default {
    components: {
        "newest-case-listing": require("../components/data/CaseTableComponent.vue").default,
        "navigation-bar": require('../components/navbar/NavbarComponent.vue').default,
        "generic-modal": require('../components/modals/GenericModalComponent.vue').default,
        //"assignment-form": require('../components/forms/QCWorkerAssignFormComponent.vue').default,
    }
}
</script>