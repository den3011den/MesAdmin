window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Операция выполнена успешно", { timeOut: 5000});
    }
    if (type === "error") {
        toastr.error(message, "Ошибка выполнения операции", { timeOut: 5000 });
    }
}