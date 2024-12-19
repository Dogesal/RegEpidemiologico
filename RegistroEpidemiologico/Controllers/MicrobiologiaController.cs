using CAPA_NEGOCIO;
using Microsoft.AspNetCore.Mvc;

namespace RegistroEpidemiologico.Controllers
{
    public class MicrobiologiaController : Controller
    {
        private readonly MicrobiologiaBL _context;

        public MicrobiologiaController(MicrobiologiaBL context)
        {
            _context = context;
        }
       
        public IActionResult getMicrobiologia()
        {
            return new JsonResult(_context.getMicrobiologia());
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
