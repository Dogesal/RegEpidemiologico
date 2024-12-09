using System;
using System.Collections.Generic;

namespace RegistroEpidemiologico;

public partial class VigilanciaEpidemiologica
{
    public int IdVigiancia { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdDx1 { get; set; }

    public int? IdDx2 { get; set; }

    public int? IdDx3 { get; set; }

    public int? IdDx4 { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<ReporteEpidemiologico> ReporteEpidemiologicos { get; set; } = new List<ReporteEpidemiologico>();
}
