using System;
using System.Collections.Generic;

namespace DL;

public partial class Producto
{
    public int Idproducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public string Imagen { get; set; } = null!;

    public int Idsubcategoria2 { get; set; }

    public int Stock { get; set; }

    public virtual Subcategoria2 Idsubcategoria2Navigation { get; set; } = null!;
}
