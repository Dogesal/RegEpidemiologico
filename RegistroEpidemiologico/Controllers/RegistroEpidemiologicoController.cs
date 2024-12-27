using CAPA_ENTIDAD.DTO;
using CAPA_NEGOCIO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RegistroEpidemiologico.Controllers
{
    public class RegistroEpidemiologicoController : Controller
    {
        private readonly ReporteEpidemiologicoBL _reporteEpidemiologico;

        public RegistroEpidemiologicoController(ReporteEpidemiologicoBL reporteEpidemiologico)
        {
            _reporteEpidemiologico = reporteEpidemiologico;
        }

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

        [HttpPost]
        public IActionResult guardarReporteEpidemiologico([FromBody] DatosRegistroEpidemiologicoDTO datosRegistroEpidemiologicoDTO)
        {
            return new JsonResult(_reporteEpidemiologico.guardarRegistroEpidemiologico(datosRegistroEpidemiologicoDTO));
        }

        public IActionResult datosRegistro(string DNI)
        {
            return new JsonResult(_reporteEpidemiologico.datosPacienteRegistro(DNI));
        }

        public IActionResult ultimoRegistro(string DNI)
        {
            return new JsonResult(_reporteEpidemiologico.ultimoRegistroConDispositivos(DNI));
        }

        public IActionResult ultimoRegistroiD(string DNI,int ID)
        {
            return new JsonResult(_reporteEpidemiologico.ultimoRegistroConDispositivos(DNI,ID));
        }

    }
}
