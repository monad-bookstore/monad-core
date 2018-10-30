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
                <span class="table-remove"><button type="button" class="btn btn-primary btn-rounded btn-sm m-0">Peržiūrėti</button></span>
            </td>
        </tr>
    </section>
</template>
<script>
import moment from 'moment'

export default {
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