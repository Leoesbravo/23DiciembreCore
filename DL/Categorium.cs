using System;
using System.Collections.Generic;

namespace DL;

public partial class Categorium
{
    public int Idcategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Subcategorium> Subcategoria { get; set; } = new List<Subcategorium>();
}
