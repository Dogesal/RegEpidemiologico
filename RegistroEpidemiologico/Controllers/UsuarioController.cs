using CAPA_NEGOCIO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RegistroEpidemiologico.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioBL _context;

        // El constructor ahora inyecta el servicio ServiciosBL
        public UsuarioController(UsuarioBL context)
        {
            _context = context; // Aquí se inicializa el servicio con la inyección de dependencias
        }

        // GET: Usuario
        public IActionResult Index()
        {


            return View();
        }

        // Acción POST para verificar la contraseña
        [HttpPost]
        public JsonResult verificarPassword([FromBody] Usuario login)
        {

            int resultado = _context.verificarPassword(login.Usu, login.Clave);

            if (resultado == 1) // Si la autenticación es exitosa
            {
                HttpContext.Session.SetString("UsuarioAutenticado", "true");
                HttpContext.Session.SetString("NombreUsuario", "Juan Pérez");
            }

            return new JsonResult(resultado);
        }

        // Acción para cerrar sesión
        public IActionResult Logout()
        {
            // Limpiar la sesión
            HttpContext.Session.Remove("UsuarioAutenticado");
            HttpContext.Session.Remove("NombreUsuario");


            return RedirectToAction("Index", "Usuario");
        }
    }
}
