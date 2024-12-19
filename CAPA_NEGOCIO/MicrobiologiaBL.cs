using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroEpidemiologico;

namespace CAPA_NEGOCIO
{
    public class MicrobiologiaBL
    {
        private readonly SghrhContext _sghrhContext;

        public MicrobiologiaBL(SghrhContext sghrhContext)
        {
            _sghrhContext = sghrhContext;
        }

        public IEnumerable<object> getMicrobiologia()
        {

            return _sghrhContext.Microbiologia.ToList();

        }
    }
}
