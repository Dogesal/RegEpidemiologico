using CAPA_ENTIDAD.DTO;
using CAPA_NEGOCIO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RegistroEpidemiologico.Controllers
{
    public class PacienteController : Controller
    {
        private readonly BusquedaPaciente _context;

        public PacienteController(BusquedaPaciente context)
        {
            _context = context;
        }


        // GET: PacienteController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult getPacientes()
        {

            return new JsonResult(_context.Pacientes());

        }

        public IActionResult getPaciente(string id)
        {

            return new JsonResult(_context.BuscarPaciente(id));

        }

    }
}
