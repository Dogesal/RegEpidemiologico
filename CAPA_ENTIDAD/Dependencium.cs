using System;
using System.Collections.Generic;

namespace RegistroEpidemiologico;

public partial class Dependencium
{
    public string CodDepen { get; set; } = null!;

    public string NombreDependencia { get; set; } = null!;

    public string? Tipotexto { get; set; }

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
