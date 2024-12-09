using System;
using System.Collections.Generic;

namespace RegistroEpidemiologico;

public partial class Historium
{
    public int Nhc { get; set; }

    public string? ApePaterno { get; set; }

    public string? ApeMaterno { get; set; }

    public string? Nombres { get; set; }

    public DateTime? FecNac { get; set; }

    public string? Sexo { get; set; }

    public string? EstCiv { get; set; }

    public string Dni { get; set; } = null!;

    public string? GradInst { get; set; }

    public string? Ocup { get; set; }

    public string? DomActual { get; set; }

    public string? NomPad { get; set; }

    public string? NomMad { get; set; }

    public string? ApeCasada { get; set; }

    public int? Edad { get; set; }

    public string? DistNac { get; set; }

    public string? ProvNac { get; set; }

    public string? DptoNac { get; set; }

    public string? DistDom { get; set; }

    public string? ProvDom { get; set; }

    public string? DptoDom { get; set; }

    public string? DistPro { get; set; }

    public string? ProvPro { get; set; }

    public string? DptoPro { get; set; }

    public string? Etnia { get; set; }

    public string? Nacionalidad { get; set; }

    public string? Religion { get; set; }

    public string? Telefono { get; set; }

    public string? AcompDni { get; set; }

    public string? AcompDom { get; set; }

    public string? TipoSeg { get; set; }

    public string? NumSeg { get; set; }

    public string? CorreoElectronico { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public DateTime? FechaModificado { get; set; }

    public string? UsuarioRegistro { get; set; }

    public string? UsuarioModificado { get; set; }

    public string? EstadoPaciente { get; set; }

    public string? TipodocIdentidad { get; set; }

    public string? NumeroDocumento { get; set; }

    public string? Ubigeo { get; set; }

    public virtual ICollection<CamaPaciente> CamaPacientes { get; set; } = new List<CamaPaciente>();
}
