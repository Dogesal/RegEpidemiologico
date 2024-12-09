using System;
using System.Collections.Generic;

namespace RegistroEpidemiologico;

public partial class DispositivosMedico
{
    public int IdDispositivosMedicos { get; set; }

    public string? NombreDispositivosMedicos { get; set; }

    public string? Abreviatura { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<ServicioDispositivosMedico> ServicioDispositivosMedicos { get; set; } = new List<ServicioDispositivosMedico>();
}
