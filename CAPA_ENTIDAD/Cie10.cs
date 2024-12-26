using System;
using System.Collections.Generic;

namespace RegistroEpidemiologico;

public partial class Cie10
{
    public int Idcie10 { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descrip { get; set; } = null!;

    public string? Sexo { get; set; }

    public string? EMin { get; set; }

    public string? TeMin { get; set; }

    public string? EMax { get; set; }

    public string? TeMax { get; set; }

    public string Estado { get; set; } = null!;

    public string Tcie { get; set; } = null!;

    public string? NivcptI { get; set; }

    public string? NivcptIi { get; set; }

    public string? NivcptIii { get; set; }

    public string? NivcptIv { get; set; }

    public string? NivcptV { get; set; }

    public string? CodEspec { get; set; }

    public string? CodDepen { get; set; }

    //public virtual ICollection<ReporteEpidemiologico> ReporteEpidemiologicos { get; set; } = new List<ReporteEpidemiologico>();
}
