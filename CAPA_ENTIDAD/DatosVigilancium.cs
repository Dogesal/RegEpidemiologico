using System;
using System.Collections.Generic;

namespace RegistroEpidemiologico;

public partial class DatosVigilancium
{
    public int IdDatosVigilancia { get; set; }

    public int? Datos { get; set; }

    public string? Descripcion { get; set; }

    public int? IdServicioDispositivoMedico { get; set; }

    public int? IdDatos { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual DatosEpidemiologium? IdDatosNavigation { get; set; }

    public virtual ServicioDispositivosMedico? IdServicioDispositivoMedicoNavigation { get; set; }
}
