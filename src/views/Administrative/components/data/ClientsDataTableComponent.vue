<template>
<table id="dtBasicExample" class="table table-striped table-bordered table-editable" cellspacing="0" width="100%">
    <thead>
        <tr>
            <th class="th-sm">Vardas
                <i class="fa fa-sort float-right" aria-hidden="true"></i>
            </th>
            <th class="th-sm">Pavardė
                <i class="fa fa-sort float-right" aria-hidden="true"></i>
            </th>
            <th class="th-sm">El. paštas
                <i class="fa fa-sort float-right" aria-hidden="true"></i>
            </th>
            <th class="th-sm">Preigos lygis
                <i class="fa fa-sort float-right" aria-hidden="true"></i>
            </th>
            <th class="th-sm">Registracijos data
                <i class="fa fa-sort float-right" aria-hidden="true"></i>
            </th>
            <th class="th-sm">Pašalinimas</th>
            <th class="th-sm">Papildoma</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Jonas</td>
            <td>Jonaitis</td>
            <td>jonas@jonaitis.lt</td>
            <td>Klientas</td>
            <td>2018-10-30</td>
            <td><span class="table-remove"><button type="button" class="btn btn-danger btn-rounded btn-sm my-0">Panaikinti</button></span></td>
            <td>
                <span class="table-remove"><button type="button" class="btn btn-success btn-rounded btn-sm my-0">Redaguoti</button></span>
                <span class="table-remove"><button type="button" class="btn btn-primary btn-rounded btn-sm my-0">Užsakymai</button></span>
            </td>
        </tr>
        <tr>
            <td>Vardenis</td>
            <td>Pavardenis</td>
            <td>admin@monad.lt</td>
            <td>Administratorius</td>
            <td>2018-10-30</td>
            <td><span class="table-remove"><button type="button" class="btn btn-danger btn-rounded btn-sm my-0">Panaikinti</button></span></td>
            <td>
                <span class="table-remove"><button type="button" class="btn btn-success btn-rounded btn-sm my-0">Redaguoti</button></span>
                <span class="table-remove"><button type="button" class="btn btn-primary btn-rounded btn-sm my-0">Užsakymai</button></span>
            </td>
        </tr>
    </tbody>
</table>
</template>

<script>
export default {
    mounted() {
        $(document).ready(function () {
            $('#dtBasicExample').DataTable({
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.19/i18n/Lithuanian.json"
                }
            });
            $('.dataTables_length').addClass('bs-select');
        });
    },
}
</script>
