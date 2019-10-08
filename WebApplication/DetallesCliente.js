function validar() {
    //var descripcion = document.getElementById("txtDescripcion").value;
    var descripcion = $('#txtDescripcion').val();
    if (descripcion === "") {
        alert("Debes completar la descripcion");
        return false;
    }
    return true;
}