using System;
using System.Collections.Generic;

namespace RegistroEpidemiologico;

public partial class Antibiotico
{
    public int IdAntibiotico { get; set; }

    public string? NombreAntibiotico { get; set; }

    public DateTime? CreatedAt { get; set; }
}
