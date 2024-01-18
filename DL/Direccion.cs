using System;
using System.Collections.Generic;

namespace DL;

public partial class Direccion
{
    public int IdDireccion { get; set; }

    public string? Calle { get; set; }

    public string? NumeroExterior { get; set; }

    public int? IdUsuario { get; set; }

    public byte? IdColonia { get; set; }

    public virtual Colonium? IdColoniaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
