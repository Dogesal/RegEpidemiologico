using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroEpidemiologico;

namespace CAPA_NEGOCIO
{
    public class CamaBL
    {

        private readonly SghrhContext _sghrhContext;

        public CamaBL(SghrhContext sghrhContext)
        {

            _sghrhContext = sghrhContext;
        }


        public IEnumerable<object> GetCamas(string codServi)
        {
            using (var context = _sghrhContext)
            {
                var query = from s in context.Servicios
                            join e in context.Especialidades on s.CodServi equals e.CodServi
                            join sa in context.Subareas on e.CodEspec equals sa.CodEspec
                            join uc in context.Ubicacioncamas on sa.Idsubarea equals uc.Idsubarea
                            where s.CodDepen == "04" && s.CodServi == codServi
                            select new
                            {   uc.Idcama,
                                s.CodDepen,
                                s.CodServi,
                                uc.Nombrecama
                            };

                return query.ToList();
            }
        }

    }
}
