using System;
using System.Collections.Generic;

namespace RegistroEpidemiologico;

public partial class Ubicacioncama
{
    public int Idcama { get; set; }

    public int? Idsubarea { get; set; }

    public int? Idnrocuarto { get; set; }

    public int? Posicionx { get; set; }

    public int? Posiciony { get; set; }

    public int? Numerocama { get; set; }

    public string? Nombrecama { get; set; }

    public string? Comentario { get; set; }

    public string? CodUsuingreso { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public string? CodUsumodifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual ICollection<CamaPaciente> CamaPacientes { get; set; } = new List<CamaPaciente>();
}
