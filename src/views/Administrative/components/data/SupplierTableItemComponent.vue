<template>
    <section>
        <tr>
            <td>{{ identifier }}</td>
            <td>{{ named }}</td>
            <td>{{ company }}</td>
            <td>{{ director }}</td>
            <td>{{ phone }}</td>
            <td>{{ created_at_formatted }}</td>
            <td>
                <button @click="displayAlert()" v-if="control_allows_remove" class="btn btn-outline-danger btn-sm m-0">Pašalinti</button>
                <button data-toggle="modal" data-target="#edit_supplier" v-if="control_allows_edit" class="btn btn-outline-success btn-sm m-0">Redaguoti</button>
            </td>
        </tr>
    </section>
</template>
<script>
import moment from 'moment'
import confirmationAlert from 'mixins/confirmationAlert.js'

export default {
    mixins: [confirmationAlert],
    computed: {
        created_at_formatted: function() {
            return moment().format('YYYY-MM-DD HH:mm')
        },
        control_allows_remove: function() {
            return _.get(this.controller, "removeable", false)
        },
        control_allows_edit: function() {
            return _.get(this.controller, "editable", false)
        }
    },
    props: {
        identifier: {
            type: String,
            required: false,
            default: function() {
                return 0
            }
        },
        named: {
            type: String,
            required: false,
            default: function() {
                return "-"
            }
        },
        company: {
            type: String,
            required: false,
            default: function() {
                return "-"
            }
        },
        director: {
            type: String,
            required: false,
            default: function() {
                return "-"
            }
        },
        phone: {
            type: String,
            required: false,
            default: function() {
                return "-"
            }
        },
        created_at: {
            type: String,
            required: false,
            default: function() {
                return Date()
            }
        },
        controller: {
            type: Object,
            required: false,
            default: function() {
                return {
                    removeable: true,
                    editable: true
                }
            }
        }
    }
}
</script>
