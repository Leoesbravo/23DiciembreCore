using System;
using System.Collections.Generic;

namespace DL;

public partial class Subcategorium
{
    public int Idsubcategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public int Idcategoria { get; set; }

    public virtual Categorium IdcategoriaNavigation { get; set; } = null!;

    public virtual ICollection<Subcategoria2> Subcategoria2s { get; set; } = new List<Subcategoria2>();
}
