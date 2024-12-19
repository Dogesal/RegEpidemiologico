using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroEpidemiologico;

namespace CAPA_NEGOCIO
{
    public class Cie10SemmBL
    {
        private readonly SghrhContext _sghrhContext;

        public Cie10SemmBL(SghrhContext sghrhContext) { 
        
            _sghrhContext = sghrhContext;
        }

        public IEnumerable<object> getCie10() { 
        
            return _sghrhContext.CieSemms.ToList();

        }

    }
}
