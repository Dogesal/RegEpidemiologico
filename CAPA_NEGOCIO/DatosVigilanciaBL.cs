using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegistroEpidemiologico;

namespace CAPA_NEGOCIO
{
    public class DatosVigilanciaBL
    {

        private readonly SghrhContext _sghrhContext;

        public DatosVigilanciaBL(SghrhContext sghrhContext)
        {
            _sghrhContext = sghrhContext;
        }

        public string guardarDatosVigilancia(DatosVigilancium datosVigilancium,int idCreado)
        {
            try
            {

                datosVigilancium.IdDatos = idCreado;  // Relacionar con el ID de DatosEpidemiologium
                _sghrhContext.DatosVigilancia.Add(datosVigilancium);  // Agregar cada DatosVigilancium

                // Guardar los cambios de DatosVigilancia
                _sghrhContext.SaveChanges();

                // Retornar mensaje de éxito
                return $"Datos de vigilancia guardados con éxito. ID de DatosEpidemiologium generado: {idCreado} y datosViligancia:{datosVigilancium.IdDatosVigilancia} ";
            }
            catch (DbUpdateException ex)
            {
                // Capturar errores relacionados con la base de datos
                return $"Error al actualizar la base de datos: {ex.Message}";
            }
            catch (Exception ex)
            {
                // Capturar cualquier otro error general
                return $"Ocurrió un error inesperado: {ex.Message}";
            }
        }




    }
}
