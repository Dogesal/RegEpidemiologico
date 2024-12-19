using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroEpidemiologico;

namespace CAPA_NEGOCIO
{
    public  class AntibioticoBL
    {
        private readonly SghrhContext _sghrhContext;

        public AntibioticoBL(SghrhContext sghrhContext)
        {
            _sghrhContext = sghrhContext;
        }

        public IEnumerable<object> getAntibioticos() {

            return _sghrhContext.Antibioticos.ToList();
        
        }
    }
}
