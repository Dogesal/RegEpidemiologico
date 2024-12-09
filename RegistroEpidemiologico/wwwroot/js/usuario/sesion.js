function CerrarSesion() {
    $.ajax({
        type: "POST",
        url:'/Usuario/Logout', 
        success: function () {
            location.reload();
        },
        error: function () {
            alert("Error al cerrar sesión. Intenta nuevamente.");
        }
    });
}
