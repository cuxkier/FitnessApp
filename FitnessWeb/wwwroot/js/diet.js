var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/diet/getall'},
        "columns": [
        { data: 'dietName', "width": "15%" },
        { data: 'dietsCategory.categoryName', "width": "65%" },
        { data: 'kcal', "width": "15%" },
        { data: 'description', "width": "5%" },
        { data: 'price', "width": "65%" },
        {
            data: 'id',
            "render": function (data) {
                return `<div class="w-75 btn-group" role="group">
                <a href="/admin/diet/upsert?id=${data}" class="btn btn-primary mx-2" <i class="bi bi-pencil-square"></i>Edytuj</a>
                <a onClick=Delete('/admin/diet/delete/${data}') class="btn btn-danger mx-2" <i class="bi bi-trash-fill"></i>Usuń</a>
            </div>`
            },
            "width": "5%"
            }
    ]
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