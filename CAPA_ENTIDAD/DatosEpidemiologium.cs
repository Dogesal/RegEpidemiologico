using System;
using System.Collections.Generic;

namespace RegistroEpidemiologico;

public partial class DatosEpidemiologium
{
    public int IdDatos { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<DatosVigilancium> DatosVigilancia { get; set; } = new List<DatosVigilancium>();

    public virtual ICollection<ReporteEpidemiologico> ReporteEpidemiologicos { get; set; } = new List<ReporteEpidemiologico>();
}
