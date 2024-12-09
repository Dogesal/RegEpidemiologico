using System;
using System.Collections.Generic;

namespace RegistroEpidemiologico;

public partial class CamaPaciente
{
    public int IdCamaPaciente { get; set; }

    public int? IdCama { get; set; }

    public string? IdPaciente { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public DateTime? FechaSalida { get; set; }

    public bool? Antivo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Ubicacioncama? IdCamaNavigation { get; set; }

    public virtual Historium? IdPacienteNavigation { get; set; }

    public virtual ICollection<ReporteEpidemiologico> ReporteEpidemiologicos { get; set; } = new List<ReporteEpidemiologico>();
}
