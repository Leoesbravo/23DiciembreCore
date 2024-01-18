using System;
using System.Collections.Generic;

namespace DL;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string? ApellidoMaterno { get; set; }

    public int Edad { get; set; }

    public int? IdRol { get; set; }

    public byte[]? Imagen { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
    public string Calle { get; set; }
    public int IdColonia { get; set; }

    public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

    public virtual Rol? IdRolNavigation { get; set; }
}
