using System;
using System.Collections.Generic;

namespace RegistroEpidemiologico;

public partial class VigilanciaEpidemiologica
{
    public int IdVigilancia { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Dx1 { get; set; }

    public string? Dx2 { get; set; }

    public string? Dx3 { get; set; }

    public string? Dx4 { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<ReporteEpidemiologico> ReporteEpidemiologicos { get; set; } = new List<ReporteEpidemiologico>();
}
