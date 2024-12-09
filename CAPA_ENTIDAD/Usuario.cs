using System;
using System.Collections.Generic;

namespace RegistroEpidemiologico;

public partial class Usuario
{
    public string? Idsis { get; set; }

    public int Idtrabajador { get; set; }

    public string Dni { get; set; } = null!;

    public string? Apepaterno { get; set; }

    public string? Apematerno { get; set; }

    public string? Nombres { get; set; }

    public string Usu { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public string? Estado { get; set; }

    public DateOnly? Desdetrabaja { get; set; }

    public DateOnly? Hastatrabaja { get; set; }

    public string? Acceso { get; set; }

    public DateTime? FecAper { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? ServDep { get; set; }

    public string? Nrorecibo { get; set; }
}
