var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    $.ajax({
        url: '/admin/diet/getall',
        type: 'GET',
        success: function (response) {
            console.log('Response from server:', response); // Sprawdzenie odpowiedzi serwera w konsoli
            // Filtrowanie danych po stronie klienta
            const filteredData = response.data.filter(diet => diet.dietsCategory.categoryName === 'Dieta Ketogeniczna');
            console.log('Filtered data:', filteredData); // Sprawdzenie przefiltrowanych danych w konsoli

            // Sprawdzenie, czy są przefiltrowane dane
            if (filteredData.length === 0) {
                console.warn('No diets match the category "Dieta Ketogeniczna"');
            }

            // Inicjalizacja DataTables z przefiltrowanymi danymi
            dataTable = $('#tblData').DataTable({
                data: filteredData,
                columns: [
                    { data: 'dietName', "width": "15%" },
                    { data: 'dietsCategory.categoryName', "width": "15%" },
                    { data: 'kcal', "width": "15%" },
                    { data: 'description', "width": "25%" },
                    { data: 'price', "width": "15%" },
                    {
                        data: 'id',
                        "render": function (data) {
                            return `<div class="w-75 btn-group" role="group">
                            <a href="/admin/diet/upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i>Edytuj</a>
                            <a onClick=Delete('/admin/diet/delete/${data}') class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i>Usuń</a>
                        </div>`;
                        },
                        "width": "15%"
                    }
                ]
            });
        },
        error: function (xhr, status, error) {
            console.error('Error loading data: ', error);
        }
    });
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            });
        }
    });
}
