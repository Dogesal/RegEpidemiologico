using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroEpidemiologico;

namespace CAPA_NEGOCIO
{
    public class DatosEpidemiologiaBL
    {
        private readonly SghrhContext _sghrhContext;

        public DatosEpidemiologiaBL(SghrhContext sghrhContext)
        {
            _sghrhContext = sghrhContext;
        }


        public int crearIdDatos() {


            // Crear una nueva instancia de DatosEpidemiologium
            var nuevoDatosEpidemiologium = new DatosEpidemiologium
            {
                CreatedAt = DateTime.Now
            };

            // Agregar el nuevo objeto al contexto
            _sghrhContext.DatosEpidemiologia.Add(nuevoDatosEpidemiologium);

            // Guardar los cambios de DatosEpidemiologium
            _sghrhContext.SaveChanges();

            // Obtener el ID generado para DatosEpidemiologium
            int idCreado = nuevoDatosEpidemiologium.IdDatos;

            return idCreado;

        }

    }
}
