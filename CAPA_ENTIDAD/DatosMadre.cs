using System;
using System.Collections.Generic;

namespace RegistroEpidemiologico;

public partial class DatosMadre
{
    public int IdDatosMadre { get; set; }

    public string? TipoLiquidoAmniotico { get; set; }

    public string? TipoParto { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Dni { get; set; }

    public string? Direccion { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<ReporteEpidemiologico> ReporteEpidemiologicos { get; set; } = new List<ReporteEpidemiologico>();
}
