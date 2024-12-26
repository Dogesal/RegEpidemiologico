using System;
using System.Collections.Generic;

namespace RegistroEpidemiologico;

public partial class ReporteEpidemiologico
{
    public int IdReporte { get; set; }

    public DateTime? FechaGeneracion { get; set; }

    public int? IdDatosNeonato { get; set; }

    public int? IdDatosMadre { get; set; }

    public int? IdVigilancia { get; set; }

    public int? IdCamaPaciente { get; set; }

    public string? IdDniPersonalSalud { get; set; }

    public string? IdServicio { get; set; }

    public int? IdDatos { get; set; }

    public string? DxIngreso { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? IdDependencia { get; set; }

    public string? IdDniPaciente { get; set; }
    public virtual CamaPaciente? IdCamaPacienteNavigation { get; set; }

    public virtual DatosMadre? IdDatosMadreNavigation { get; set; }

    public virtual DatosEpidemiologium? IdDatosNavigation { get; set; }

    public virtual DatosNeonato? IdDatosNeonatoNavigation { get; set; }

    public virtual Empleado? IdDniPersonalSaludNavigation { get; set; }

    //public virtual Cie10? IdDxNavigation { get; set; }

    public virtual VigilanciaEpidemiologica? IdVigilanciaNavigation { get; set; }

    public virtual Servicio? Servicio { get; set; }

    public virtual Historium? IdDniPacienteNavigation { get; set; }
}
