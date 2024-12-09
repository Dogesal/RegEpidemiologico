using System;
using System.Collections.Generic;

namespace RegistroEpidemiologico;

public partial class Empleado
{
    public string Idempleado { get; set; } = null!;

    public string Apepaterno { get; set; } = null!;

    public string Apematerno { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public int? Profesion { get; set; }

    public string? Nrocolegiatura { get; set; }

    public int? Especialidad1 { get; set; }

    public string? CodigoRne1 { get; set; }

    public int? Especialidad2 { get; set; }

    public string? CodigoRne2 { get; set; }

    public string? Cargo { get; set; }

    public string? Tipoplaza { get; set; }

    public string Celular { get; set; } = null!;

    public string? Idespegeneral { get; set; }

    public string? Idespegeneral2 { get; set; }

    public virtual ICollection<ReporteEpidemiologico> ReporteEpidemiologicos { get; set; } = new List<ReporteEpidemiologico>();
}
