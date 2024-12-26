using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_ENTIDAD.DTO;
using RegistroEpidemiologico;

namespace CAPA_NEGOCIO
{
    public class ReporteEpidemiologicoBL
    {
        private readonly SghrhContext _sghrhContext;

        public ReporteEpidemiologicoBL(SghrhContext sghrhContext)
        {
            _sghrhContext = sghrhContext;
        }
        // Función para verificar si un objeto es vacío
        private bool EsVacio(object obj)
        {
            // Si el objeto es nulo, consideramos que está vacío
            if (obj == null)
                return true;

            // Verificar si el objeto es un objeto tipo "datosMadre" o "datosNeonato" y si todos sus campos están vacíos
            if (obj is DatosMadre datosMadre)
            {
                return string.IsNullOrEmpty(datosMadre.TipoLiquidoAmniotico) &&
                       string.IsNullOrEmpty(datosMadre.TipoParto) &&
                       string.IsNullOrEmpty(datosMadre.NombreCompleto) &&
                       string.IsNullOrEmpty(datosMadre.Dni) &&
                       string.IsNullOrEmpty(datosMadre.Direccion);
            }
            if (obj is DatosNeonato datosNeonato)
            {
                return string.IsNullOrEmpty(datosNeonato.PerimetroCefaleo) &&
                       string.IsNullOrEmpty(datosNeonato.PerimetroToraxico) &&
                       string.IsNullOrEmpty(datosNeonato.PerimetroAbdominal) &&
                       string.IsNullOrEmpty(datosNeonato.Apgan);
            }

            return false; // Si no es un tipo conocido, asumimos que no es vacío
        }
        public string guardarRegistroEpidemiologico(DatosRegistroEpidemiologicoDTO datosRegistro)
        {
            try
            {

                ReporteEpidemiologico reporteEpidemiologico = new ReporteEpidemiologico();
                // Crea id para datos
                DatosEpidemiologiaBL datosEpidemiologia = new DatosEpidemiologiaBL(_sghrhContext);
                int idDatos = datosEpidemiologia.crearIdDatos();

                // Guarda datos de vigilancia
                DatosVigilanciaBL datosVigilancia = new DatosVigilanciaBL(_sghrhContext);
                foreach (DatosVigilancium datosVigilancium1 in datosRegistro.DatosVigilancium)
                {
                    try
                    {
                        datosVigilancia.guardarDatosVigilancia(datosVigilancium1, idDatos);
                    }
                    catch (Exception ex)
                    {
                        return $"Error al guardar datos de vigilancia: {ex.Message}";
                    }
                }

                // Guarda datos de madre si existen
                // Guarda los datos de la madre solo si existen
                if (datosRegistro.datosMadre != null && !EsVacio(datosRegistro.datosMadre))
                {
                    try
                    {
                        // Agregar los datos de la madre al contexto
                        _sghrhContext.DatosMadre.Add(datosRegistro.datosMadre);
                        _sghrhContext.SaveChanges();

                        // Obtener el ID generado por la base de datos
                        int idMadre = datosRegistro.datosMadre.IdDatosMadre;
                        reporteEpidemiologico.IdDatosMadre = idMadre;
                    }
                    catch (Exception ex)
                    {
                        // Registrar detalles del error
                        return $"Error al guardar datos de madre: {ex.Message}\nStackTrace: {ex.StackTrace}";
                    }
                }

                // Guarda los datos del neonato solo si existen
                if (datosRegistro.datosNeonato != null && !EsVacio(datosRegistro.datosNeonato))
                {
                    try
                    {
                        // Agregar los datos del neonato al contexto
                        _sghrhContext.DatosNeonato.Add(datosRegistro.datosNeonato);
                        _sghrhContext.SaveChanges();

                        // Obtener el ID generado por la base de datos
                        int idNeonato = datosRegistro.datosNeonato.IdDatosNeonato;
                        reporteEpidemiologico.IdDatosNeonato = idNeonato;
                    }
                    catch (Exception ex)
                    {
                        // Registrar detalles del error
                        return $"Error al guardar datos de neonato: {ex.Message}\nStackTrace: {ex.StackTrace}";
                    }
                }




                // Guarda datos de vigilancia epidemiológica
                try
                {
                    _sghrhContext.VigilanciaEpidemiologica.Add(datosRegistro.VigilanciaEpidemiologica);

                    // Guardar cambios en la base de datos
                    _sghrhContext.SaveChanges();

                    // Obtener el ID generado
                    int IdVigilancia = datosRegistro.VigilanciaEpidemiologica.IdVigilancia;
                    reporteEpidemiologico.IdVigilancia = IdVigilancia;
                }
                catch (Exception ex)
                {
                    return $"Error al guardar datos de vigilancia epidemiológica: {ex.Message}\nInnerException: {ex.InnerException?.Message}";
                }


                // Guarda HISTORIAL DE CAMA
                try
                {

                    CamaPaciente camaPaciente = new CamaPaciente();

                    camaPaciente.IdCama = datosRegistro.IdCama;
                    camaPaciente.IdPaciente = datosRegistro.DNI;
                    camaPaciente.FechaIngreso = DateTime.Now;

                    camaPaciente.Antivo = true;

                    _sghrhContext.CamaPacientes.Add(camaPaciente);

                    // Guardar cambios en la base de datos
                    _sghrhContext.SaveChanges();

                    // Obtener el ID generado
                    int IdCamaPaciente = camaPaciente.IdCamaPaciente;
                    reporteEpidemiologico.IdCamaPaciente = IdCamaPaciente;
                }
                catch (Exception ex)
                {
                    return $"Error al guardar datos de vigilancia epidemiológica: {ex.Message}\nInnerException: {ex.InnerException?.Message}";
                }

                // Guarda el resto de los datos del reporte
                try
                {
                    reporteEpidemiologico.FechaGeneracion = datosRegistro.fecha_generacion;
                    reporteEpidemiologico.IdDatos = idDatos;
                    reporteEpidemiologico.DxIngreso = datosRegistro.Dx_ingreso;
                    reporteEpidemiologico.IdDniPersonalSalud = datosRegistro.DNI_personal;
                    reporteEpidemiologico.IdDniPaciente = datosRegistro.DNI;
                    reporteEpidemiologico.IdDependencia = "04";
                    reporteEpidemiologico.IdServicio = datosRegistro.IdServicio;

                    _sghrhContext.ReporteEpidemiologico.Add(reporteEpidemiologico);
                    _sghrhContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    return $"Error al guardar el reporte epidemiológico: {ex.Message}\nInnerException: {ex.InnerException?.Message}";
                }

                return "Registrado correctamente";
            }
            catch (Exception ex)
            {
                // Captura cualquier error general en el proceso
                return $"Error general al guardar el registro epidemiológico: {ex.Message}";
            }
        }

    }
}
