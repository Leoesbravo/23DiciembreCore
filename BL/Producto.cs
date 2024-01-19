using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static Dictionary<string, object> GetAll()
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", "" }, { "Resultado", false }, { "Producto", null } };
            try
            {
                using (DL.LescogidoNormalizacionContext context = new DL.LescogidoNormalizacionContext())
                {
                    //Entity Framework
                    //FromSqlRaw--joins
                    //var registrosLinq = context.Usuarios.ToList();


                    //LINQ

                    var registros = (from productos in context.Productos
                                     select new
                                     {
                                         IdProducto = productos.Idproducto,
                                         Nombre = productos.Nombre,
                                         Precio = productos.Precio,
                                         Descripcion = productos.Descripcion,
                                         Imagen = productos.Imagen,
                                     }).ToList();



                    //DL.Usuario usuar = new DL.Usuario();
                    //var filasAfectadas = context.Usuarios.Add(usuar);
                    if (registros.Count > 0)
                    {
                        ML.Producto producto = new ML.Producto();
                        producto.Productos = new List<object>();
                        foreach (var registro in registros)
                        {
                            ML.Producto product = new ML.Producto();
                            product.Idproducto = registro.IdProducto;
                            product.Nombre = registro.Nombre;
                            product.Precio = registro.Precio;
                            product.Descripcion = registro.Descripcion;
                            product.Imagen = registro.Imagen;

                            producto.Productos.Add(product);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Producto"] = producto;
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                diccionario["Exepcion"] = ex;
            }
            return diccionario;
        }
        public static Dictionary<string, object> GetById(int idProducto)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", "" }, { "Resultado", false }, { "Producto", null } };
            try
            {
                using (DL.LescogidoNormalizacionContext context = new DL.LescogidoNormalizacionContext())
                {
                    //Entity Framework
                    //FromSqlRaw--joins
                    //var registrosLinq = context.Usuarios.ToList();


                    //LINQ

                    var registros = (from productos in context.Productos
                                     where productos.Idproducto == idProducto
                                     select new
                                     {
                                         IdProducto = productos.Idproducto,
                                         Nombre = productos.Nombre,
                                         Precio = productos.Precio,
                                         Descripcion = productos.Descripcion,
                                         Imagen = productos.Imagen,
                                     }).FirstOrDefault();



                    //DL.Usuario usuar = new DL.Usuario();
                    //var filasAfectadas = context.Usuarios.Add(usuar);
                    if (registros != null)
                    {

                        ML.Producto product = new ML.Producto();
                        product.Idproducto = registros.IdProducto;
                        product.Nombre = registros.Nombre;
                        product.Precio = registros.Precio;
                        product.Descripcion = registros.Descripcion;
                        product.Imagen = registros.Imagen;



                        diccionario["Resultado"] = true;
                        diccionario["Producto"] = product;
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                diccionario["Exepcion"] = ex;
            }
            return diccionario;
        }
    }
}
