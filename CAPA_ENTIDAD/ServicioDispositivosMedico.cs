using System;
using System.Collections.Generic;

namespace RegistroEpidemiologico;

public partial class ServicioDispositivosMedico
{
    public int IdServicioDispositivosMedicos { get; set; }

    public int? IdDispositivosMedicos { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<DatosVigilancium> DatosVigilancia { get; set; } = new List<DatosVigilancium>();

    public string IdServicio { get; set; } = null!;

    public string IdDependencia { get; set; } = null!;
    public virtual DispositivosMedico? IdDispositivosMedicosNavigation { get; set; }
}

