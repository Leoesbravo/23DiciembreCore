using System;
using System.Collections.Generic;

namespace DL;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string? Titulo { get; set; }

    public virtual ICollection<AutorLibro> AutorLibros { get; set; } = new List<AutorLibro>();
}
