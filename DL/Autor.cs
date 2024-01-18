using System;
using System.Collections.Generic;

namespace DL;

public partial class Autor
{
    public int IdAutor { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<AutorLibro> AutorLibros { get; set; } = new List<AutorLibro>();
}
