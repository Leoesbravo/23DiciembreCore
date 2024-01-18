using System;
using System.Collections.Generic;

namespace DL;

public partial class Subcategoria2
{
    public int Idsubcategoria2 { get; set; }

    public string Nombre { get; set; } = null!;

    public int Idsubcategoria { get; set; }

    public virtual Subcategorium IdsubcategoriaNavigation { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
