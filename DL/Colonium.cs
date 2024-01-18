using System;
using System.Collections.Generic;

namespace DL;

public partial class Colonium
{
    public byte IdColonia { get; set; }

    public string? Nombre { get; set; }

    public byte? IdMunicipio { get; set; }

    public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

    public virtual Municipio? IdMunicipioNavigation { get; set; }
}
