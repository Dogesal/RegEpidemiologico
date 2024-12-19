using CAPA_NEGOCIO;
using Microsoft.AspNetCore.Mvc;

namespace RegistroEpidemiologico.Controllers
{
    public class DispositivosMedicosController : Controller
    {
        private readonly DispositivosMedicosBL _context;

        public DispositivosMedicosController(DispositivosMedicosBL dispositivosMedicosBL) { 
       
            _context = dispositivosMedicosBL;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult getDispositivosMedicos()
        {

            return new JsonResult(_context.getDispositivosMedicos());

        }

        public IActionResult getDispositivosMedicosServicio(string servicio)
        {

            return new JsonResult(_context.getServicioDispositivosMedicos(servicio));

        }
    }
}
