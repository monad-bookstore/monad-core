<template>
    <section>
        <tr>
            <td>{{ identifier }}</td>
            <td>{{ orderId }}</td>
            <td>{{ client }}</td>
            <td>{{ priceTotal }}&euro;</td>
            <td>{{ status }}</td>
            <td>{{ created_at_formatted }}</td>
            <td>
                <span class="table-remove">
                    <a target="_blank" href="/order-overview">
                        <button  type="button" class="btn btn-primary btn-rounded btn-sm m-0">Peržiūrėti</button>                    
                    </a>
                </span>
                <!--Dropdown primary-->
                <div class="btn-group">
                    <div class="dropdown">
                        <!--Trigger-->
                        <button class="btn btn-sm btn-primary dropdown-toggle" type="button" id="dropdownMenu2" data-toggle="dropdown"
                        aria-haspopup="true" aria-expanded="false">Kurjerio meniu</button>


                        <!--Menu-->
                        <div class="dropdown-menu dropdown-primary">
                            <a class="dropdown-item" @click="displayAlert()">Prisiimti užsakymą</a>
                            <a class="dropdown-item" data-toggle="modal" data-target="#client_contact">Susisiekti su užsakovu</a>
                        </div>
                    </div>
                    <!--/Dropdown primary-->
                </div>
            </td>
        </tr>
    </section>
</template>
<script>
import moment from 'moment'
import swal from 'sweetalert2'

export default {
    methods: {
        displayAlert() {
            swal({
                title: 'Ar tikrai?',
                text: "Šio žingsnio atkurti neįmanoma!",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                cancelButtonText: 'Atšaukti',
                confirmButtonText: 'Taip'
              }).then((result) => {
                if (result.value) {
                  swal(
                    'Prisiimta!',
                    'Užsakymas sėkmingai prisiimtas.',
                    'success'
                  )
                }
              })
        }
    },
    computed: {
        created_at_formatted: function() {
            return moment().format('YYYY-MM-DD HH:mm')
        },
    },
    props: {
        identifier: {
            type: String,
            required: false,
            default: function() {
                return 0
            }
        },
        orderId: {
            type: String,
            required: false,
            default: function() {
                return "#000000"
            }
        },
        client: {
            type: String,
            required: false,
            default: function() {
                return "-"
            }
        },
        priceTotal: {
            type: String,
            required: false,
            default: function() {
                return "0.0"
            }
        },
        status: {
            type: String,
            required: false,
            default: function() {
                return "Vykdoma"
            }
        },
        created_at: {
            type: String,
            required: false,
            default: function() {
                return Date()
            }
        },
    }
}
</script>