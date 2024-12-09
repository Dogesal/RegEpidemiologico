using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RegistroEpidemiologico.Controllers
{
    public class RegistroEpidemiologicoController : Controller
    {


        // GET: RegistroEpidemiologicoController
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult RegistroEpidemiologico()
        {
            return View();
        }
        public ActionResult Servicio()
        {
            return View();
        }

        // POST: RegistroEpidemiologicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}
