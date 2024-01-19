using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
        public int Idproducto { get; set; }

        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public decimal Precio { get; set; }

        public string Imagen { get; set; } = null!;

        public int Idsubcategoria2 { get; set; }

        public int Stock { get; set; }
        public List<object> Productos { get; set; }
    }
}
