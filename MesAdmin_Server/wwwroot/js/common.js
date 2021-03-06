window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Операция выполнена успешно", { timeOut: 5000});
    }
    if (type === "error") {
        toastr.error(message, "Ошибка выполнения операции", { timeOut: 5000 });
    }
}


window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Успешная операция!',
            message,
            'success'
        )
    }
    if (type === "error") {
        Swal.fire(
            'Ошибка операции!',
            message,
            'error'
        )
    }
}

function ShowDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}