using System;
using System.Collections.Generic;

namespace RegistroEpidemiologico;

public partial class Servicio
{
    public string CodDepen { get; set; } = null!;

    public string CodServi { get; set; } = null!;

    public string NombreServicio { get; set; } = null!;

    public virtual Dependencium CodDepenNavigation { get; set; } = null!;

    public virtual ICollection<ReporteEpidemiologico> ReporteEpidemiologicos { get; set; } = new List<ReporteEpidemiologico>();
}
