using System;
using System.Collections.Generic;

namespace DL;

public partial class AutorLibro
{
    public int IdAutorLibro { get; set; }

    public int IdLibro { get; set; }

    public int IdAutor { get; set; }

    public virtual Autor IdAutorNavigation { get; set; } = null!;

    public virtual Libro IdLibroNavigation { get; set; } = null!;
}
