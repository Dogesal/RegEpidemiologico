using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroEpidemiologico;

namespace CAPA_NEGOCIO
{
    public class ServicioBL
    {

        private readonly SghrhContext _sghrhContext;

        public ServicioBL(SghrhContext sghrhContext)
        {
            _sghrhContext = sghrhContext;
        }


        public IEnumerable<object> getServicios()
        {

            return _sghrhContext.Servicios.Where(a => a.CodDepen == "04").ToList();

        }

    }
}
