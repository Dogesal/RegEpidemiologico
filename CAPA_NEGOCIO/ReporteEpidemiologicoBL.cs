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
            // Inicia una transacción en el contexto de base de datos
            using (var transaction = _sghrhContext.Database.BeginTransaction())
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
                            // Revierte la transacción si hay error
                            transaction.Rollback();
                            return $"Error al guardar datos de vigilancia: {ex.Message}";
                        }
                    }

                    // Guarda datos de madre si existen
                    if (datosRegistro.datosMadre != null && !EsVacio(datosRegistro.datosMadre))
                    {
                        try
                        {
                            _sghrhContext.DatosMadre.Add(datosRegistro.datosMadre);
                            _sghrhContext.SaveChanges();

                            int idMadre = datosRegistro.datosMadre.IdDatosMadre;
                            reporteEpidemiologico.IdDatosMadre = idMadre;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            return $"Error al guardar datos de madre: {ex.Message}\nStackTrace: {ex.StackTrace}";
                        }
                    }

                    // Guarda datos de neonato si existen
                    if (datosRegistro.datosNeonato != null && !EsVacio(datosRegistro.datosNeonato))
                    {
                        try
                        {
                            _sghrhContext.DatosNeonato.Add(datosRegistro.datosNeonato);
                            _sghrhContext.SaveChanges();

                            int idNeonato = datosRegistro.datosNeonato.IdDatosNeonato;
                            reporteEpidemiologico.IdDatosNeonato = idNeonato;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            return $"Error al guardar datos de neonato: {ex.Message}\nStackTrace: {ex.StackTrace}";
                        }
                    }

                    // Guarda datos de vigilancia epidemiológica
                    try
                    {
                        _sghrhContext.VigilanciaEpidemiologica.Add(datosRegistro.VigilanciaEpidemiologica);
                        _sghrhContext.SaveChanges();

                        int IdVigilancia = datosRegistro.VigilanciaEpidemiologica.IdVigilancia;
                        reporteEpidemiologico.IdVigilancia = IdVigilancia;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al guardar datos de vigilancia epidemiológica: {ex.Message}\nInnerException: {ex.InnerException?.Message}";
                    }

                    // Guarda historial de cama
                    try
                    {
                        CamaPaciente camaPaciente = new CamaPaciente
                        {
                            IdCama = datosRegistro.IdCama,
                            IdPaciente = datosRegistro.DNI,
                            FechaIngreso = DateTime.Now,
                            Antivo = true
                        };

                        _sghrhContext.CamaPacientes.Add(camaPaciente);
                        _sghrhContext.SaveChanges();

                        int IdCamaPaciente = camaPaciente.IdCamaPaciente;
                        reporteEpidemiologico.IdCamaPaciente = IdCamaPaciente;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al guardar datos de cama: {ex.Message}\nInnerException: {ex.InnerException?.Message}";
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

                        if (datosRegistro.fecha_ingreso != null)
                        {
                            reporteEpidemiologico.FechaIngreso = datosRegistro.fecha_ingreso;
                        }

                        _sghrhContext.ReporteEpidemiologico.Add(reporteEpidemiologico);
                        _sghrhContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al guardar el reporte epidemiológico: {ex.Message}\nInnerException: {ex.InnerException?.Message}";
                    }

                    // Commit de la transacción si todo salió bien
                    transaction.Commit();

                    return "Registrado correctamente";
                }
                catch (Exception ex)
                {
                    // Revierte la transacción en caso de cualquier error general
                    transaction.Rollback();
                    return $"Error general al guardar el registro epidemiológico: {ex.Message}";
                }
            }
        }
        public IEnumerable<object> datosPacienteRegistro(string DNI)
        {
            var query = from re in _sghrhContext.ReporteEpidemiologico
                        join se in _sghrhContext.Servicios on re.IdServicio equals se.CodServi
                        join hi in _sghrhContext.Historia on re.IdDniPaciente equals hi.Dni
                        where re.IdDniPaciente == DNI && se.CodDepen == "04" 
                        select new
                        {
                            ID_registro= re.IdReporte,
                            DniHistoria = hi.Dni + "<br>" + hi.Nhc,  // Para HTML


                            Fecha_generado = re.FechaGeneracion.HasValue
                                    ? re.FechaGeneracion.Value.ToString("yyyy-MM-dd")  // Formatear como string
                                    : null,
                            Servicio = se.NombreServicio


                        };
                        
            return query.ToList();


        }

        public object ultimoRegistroConDispositivos(string DNI)
        {
            var query = (from re in _sghrhContext.ReporteEpidemiologico
                         join dv in _sghrhContext.DatosVigilancia on re.IdDatos equals dv.IdDatos
                         join sd in _sghrhContext.ServicioDispositivosMedicos on dv.IdServicioDispositivoMedico equals sd.IdServicioDispositivosMedicos
                         join d in _sghrhContext.DispositivosMedicos on sd.IdDispositivosMedicos equals d.IdDispositivosMedicos
                         join v in _sghrhContext.VigilanciaEpidemiologica on re.IdVigilancia equals v.IdVigilancia
                         join ca in _sghrhContext.CamaPacientes on re.IdCamaPaciente equals ca.IdCamaPaciente
                         join ub in _sghrhContext.Ubicacioncamas on ca.IdCama equals ub.Idcama
                         where re.IdDniPaciente == DNI
                         orderby re.IdReporte descending
                         select new
                         {
                             ID = re.IdReporte,
                             IdCama = ub.Idcama,
                             DNI = re.IdDniPaciente,
                             fechaGeneracion = re.FechaGeneracion,
                             fechaIngreso= re.FechaIngreso,
                             Dx_ingreso = re.DxIngreso,
                             cama = ub.Nombrecama,
                             vigilancia = new
                             {
                                 observacion = v.Descripcion,
                                 dx1 = v.Dx1,
                                 dx2 = v.Dx2,
                                 dx3 = v.Dx3,
                                 dx4 = v.Dx4
                             },
                             dispositivos = (from dv2 in _sghrhContext.DatosVigilancia
                                             join sd2 in _sghrhContext.ServicioDispositivosMedicos on dv2.IdServicioDispositivoMedico equals sd2.IdServicioDispositivosMedicos
                                             join d2 in _sghrhContext.DispositivosMedicos on sd2.IdDispositivosMedicos equals d2.IdDispositivosMedicos
                                             where dv2.IdDatos == dv.IdDatos
                                             select new
                                             {
                                                 nombre_dispositivo = d2.NombreDispositivosMedicos,
                                                 descripcion = dv2.Descripcion
                                             }).ToList() // Agrupamos los dispositivos en un array
                         }).FirstOrDefault(); // Tomamos el primer registro después de ordenar por fecha

            return query;
        }


        public object ultimoRegistroConDispositivos(string DNI,int ID)
        {
            var query = (from re in _sghrhContext.ReporteEpidemiologico
                         join dv in _sghrhContext.DatosVigilancia on re.IdDatos equals dv.IdDatos
                         join sd in _sghrhContext.ServicioDispositivosMedicos on dv.IdServicioDispositivoMedico equals sd.IdServicioDispositivosMedicos
                         join d in _sghrhContext.DispositivosMedicos on sd.IdDispositivosMedicos equals d.IdDispositivosMedicos
                         join v in _sghrhContext.VigilanciaEpidemiologica on re.IdVigilancia equals v.IdVigilancia
                         join ca in _sghrhContext.CamaPacientes on re.IdCamaPaciente equals ca.IdCamaPaciente
                         join ub in _sghrhContext.Ubicacioncamas on ca.IdCama equals ub.Idcama
                         where re.IdDniPaciente == DNI && re.IdReporte==ID
                         orderby re.IdReporte descending
                         select new
                         {
                             ID = re.IdReporte,
                             IdCama = ub.Idcama,
                             DNI = re.IdDniPaciente,
                             fechaGeneracion = re.FechaGeneracion,
                             fechaIngreso = re.FechaIngreso,
                             Dx_ingreso = re.DxIngreso,
                             cama = ub.Nombrecama,
                             vigilancia = new
                             {
                                 observacion = v.Descripcion,
                                 dx1 = v.Dx1,
                                 dx2 = v.Dx2,
                                 dx3 = v.Dx3,
                                 dx4 = v.Dx4
                             },
                             dispositivos = (from dv2 in _sghrhContext.DatosVigilancia
                                             join sd2 in _sghrhContext.ServicioDispositivosMedicos on dv2.IdServicioDispositivoMedico equals sd2.IdServicioDispositivosMedicos
                                             join d2 in _sghrhContext.DispositivosMedicos on sd2.IdDispositivosMedicos equals d2.IdDispositivosMedicos
                                             where dv2.IdDatos == dv.IdDatos
                                             select new
                                             {
                                                 nombre_dispositivo = d2.NombreDispositivosMedicos,
                                                 descripcion = dv2.Descripcion
                                             }).ToList() // Agrupamos los dispositivos en un array
                         }).FirstOrDefault(); // Tomamos el primer registro después de ordenar por fecha

            return query;
        }

    }
}
