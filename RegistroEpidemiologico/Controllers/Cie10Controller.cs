using CAPA_NEGOCIO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RegistroEpidemiologico.Controllers
{
    public class Cie10Controller : Controller
    {
        private readonly Cie10SemmBL _context;

        public Cie10Controller(Cie10SemmBL context)
        {
            _context = context;
        }


        // GET: Cie10Controller
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult getCie10()
        {
            return new JsonResult( _context.getCie10());

        }

        
    }
}
