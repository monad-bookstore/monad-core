import swal from 'sweetalert2'

export default {
    methods: {
        displayAlert() {
            swal({
                title: 'Ar tikrai?',
                text: "Po ištrynimo, duomenų atkurti nebeįmanoma!",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                cancelButtonText: 'Atšaukti',
                confirmButtonText: 'Taip'
              }).then((result) => {
                if (result.value) {
                  swal(
                    'Ištrinta!',
                    'Įrašas pašalintas.',
                    'success'
                  )
                }
              })
        }
    }
}