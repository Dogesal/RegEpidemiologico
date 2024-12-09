using System;
using System.Collections.Generic;

namespace RegistroEpidemiologico;

public partial class DatosNeonato
{
    public int IdDatosNeonato { get; set; }

    public string? PerimetroCefaleo { get; set; }

    public string? PerimetroToraxico { get; set; }

    public string? PerimetroAbdominal { get; set; }

    public string? Apgan { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<ReporteEpidemiologico> ReporteEpidemiologicos { get; set; } = new List<ReporteEpidemiologico>();
}
