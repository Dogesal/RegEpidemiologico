// Función para realizar la solicitud AJAX
    function login() {
        const Usu = document.getElementById('usuario').value;
        const Clave = document.getElementById('password').value;
    const errorMessage = document.getElementById('error-message');

    // Validar que los campos no estén vacíos
        if (!Usu || !Clave) {
        errorMessage.textContent = "Por favor, complete todos los campos.";
        errorMessage.style.display = "block";
    return;
        }
        console.log(JSON.stringify({ Usu, Clave }))
    // Enviar solicitud AJAX al endpoint de verificación
    fetch('/Usuario/verificarPassword', {
        method: 'POST',
    headers: {
        'Content-Type': 'application/json'
            },
    body: JSON.stringify({Usu, Clave}) // Asegúrate de que se envíen como JSON
        })
        .then(response => response.json())
        .then(data => {
            
            if (data === 1) {
        // Redirigir a la página de inicio si las credenciales son correctas
        window.location.href = '/Home/';
            } else {
        // Mostrar mensaje de error si las credenciales son incorrectas
        errorMessage.textContent = "Usuario o contraseña incorrectos.";
    errorMessage.style.display = "block";
            }
        })
        .catch(error => {
        console.error("Error al realizar la solicitud:", error);
    errorMessage.textContent = "Ocurrió un error, intente nuevamente.";
    errorMessage.style.display = "block";
        });
    }
