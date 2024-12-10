using CAPA_NEGOCIO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RegistroEpidemiologico.Controllers
{
    public class CamaController : Controller
    {
        private readonly CamaBL _context;

        public CamaController(CamaBL context)
        {
            _context = context;
        }
        // GET: CamaController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult getCamasServicio(string id)
        {

            return new JsonResult(_context.GetCamas(id));

        }


    }
}
