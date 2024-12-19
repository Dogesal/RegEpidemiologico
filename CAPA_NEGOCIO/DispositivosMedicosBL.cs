using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroEpidemiologico;

namespace CAPA_NEGOCIO
{
    public  class DispositivosMedicosBL
    {
        private readonly SghrhContext _sghrhContext;

        public DispositivosMedicosBL(SghrhContext sghrhContext) { 
        
        _sghrhContext = sghrhContext;
        
        }

        public IEnumerable<object> getDispositivosMedicos() {

            return _sghrhContext.DispositivosMedicos.ToList();

        }

        public IEnumerable<object> getServicioDispositivosMedicos(string servicio)
        {

            var query = from dm in _sghrhContext.DispositivosMedicos
                        join sdm in _sghrhContext.ServicioDispositivosMedicos on dm.IdDispositivosMedicos equals sdm.IdDispositivosMedicos
                        join s in _sghrhContext.Servicios on sdm.IdServicio equals s.CodServi
                        where sdm.IdServicio == servicio & s.CodDepen == "04"
                        select new
                        {
                            nombre_dispositivo = dm.NombreDispositivosMedicos,
                            abreviatura = dm.Abreviatura,
                            nombre_servicio = s.NombreServicio

                        };


            return query.ToList();

        }

    }
}
