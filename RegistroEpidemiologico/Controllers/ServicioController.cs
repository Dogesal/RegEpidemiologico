using CAPA_NEGOCIO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RegistroEpidemiologico.Controllers
{
    public class ServicioController : Controller
    {
        private readonly ServicioBL _servicioBL;

        public ServicioController(ServicioBL servicioBL) { 
        
            _servicioBL = servicioBL;

        }

        // GET: ServicioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ServicioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServicioController/Create
        public ActionResult Create()
        {
            return View();
        }

        public IActionResult getServicios()
        {
            return new JsonResult(_servicioBL.getServicios());
        }
    }
}
