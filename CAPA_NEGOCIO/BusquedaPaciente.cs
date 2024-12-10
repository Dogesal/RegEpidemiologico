using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_ENTIDAD.DTO;
using RegistroEpidemiologico;

namespace CAPA_NEGOCIO
{
    public  class BusquedaPaciente
    {

        private readonly SghrhContext _sghrhContext;

        public BusquedaPaciente(SghrhContext sghrhContext)
        {

            _sghrhContext = sghrhContext;
        }

        public object BuscarPaciente(string parametro)
        {
            var fecha_Actual = DateTime.Now; // Obtener la fecha actual completa

            var query = from h in _sghrhContext.Historia
                        where h.Dni == parametro // Filtro para NHC o DNI
                        select new
                        {
                            DNI=h.Dni,
                            Nhistoria=h.Nhc,
                            Nombre=h.Nombres+" "+h.ApePaterno + " " +h.ApeMaterno,
                            Edad= h.FecNac.HasValue
                                    ? fecha_Actual.Year - h.FecNac.Value.Year -
                                      (fecha_Actual < h.FecNac.Value.AddYears(fecha_Actual.Year - h.FecNac.Value.Year) ? 1 : 0)
                                    : h.Edad, // Si FecNac es nulo, se usa el valor de "Edad" de la tabla Historia
                            Sexo =h.Sexo=="M"?"MASCULINO":"FEMENINO"
                        };

            // Obtener el primer paciente que cumpla con la condición o null si no existe
            var paciente = query.FirstOrDefault();

            return paciente;


        }

        public IEnumerable<object> Pacientes() {

            var fecha_Actual = DateTime.Now; // Obtener la fecha actual completa

            var query = from h in _sghrhContext.Historia
                        select new
                        {   
                            DNI = h.Dni,
                            Historia = h.Nhc,
                            nombre = h.Nombres + " " + h.ApePaterno + " " + h.ApeMaterno,
                            // Cálculo de la edad considerando año, mes y día
                            edad = h.FecNac.HasValue
                                    ? fecha_Actual.Year - h.FecNac.Value.Year -
                                      (fecha_Actual < h.FecNac.Value.AddYears(fecha_Actual.Year - h.FecNac.Value.Year) ? 1 : 0)
                                    : h.Edad, // Si FecNac es nulo, se usa el valor de "Edad" de la tabla Historia
                            sexo = h.Sexo
                        };

            return query.ToList();



        }




    }
}
