using Microsoft.AspNetCore.Mvc;
using ML;
using System.Drawing.Printing;

namespace PL.Controllers
{
    public class VentaController : Controller
    {
        public ActionResult Catalogo()
        {
            Dictionary<string, object> resultado = BL.Producto.GetAll();
            bool correct = (bool)resultado["Resultado"];
            if (correct)
            {
                ML.Producto producto = (ML.Producto)resultado["Producto"];
                return View(producto);
            }
            return View();
            
        }
        [HttpGet]
        public ActionResult AgregarProducto(int idProducto)
        {
            bool existe = false;
            ML.Carrito carrito = new Carrito();
            carrito.Productos = new List<object>();
            if (HttpContext.Session.GetString("Carrito") == null)
            {
                Dictionary<string, object> resultado = BL.Producto.GetById(idProducto);
                ML.Producto producto = (ML.Producto)resultado["Producto"];
                producto.Cantidad = 1;

                carrito.Productos.Add(producto);
                //Serializar el carrito
                //Crear una sesion
                HttpContext.Session.SetString("Carrito", Newtonsoft.Json.JsonConvert.SerializeObject(carrito.Productos));

                return RedirectToAction("Catalogo");
            }
            else
            {
                var carritoSession = Newtonsoft.Json.JsonConvert.DeserializeObject<List<object>>(HttpContext.Session.GetString("Carrito"));
                foreach (var producto in carritoSession)
                {
                    ML.Producto producto1 = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(producto.ToString());
                    carrito.Productos.Add(producto1);
                    if (idProducto == producto1.Idproducto)
                    {
                        existe = true;
                        //Aumentar cantidad
                        producto1.Cantidad += 1;
                        break;
                    }
                    else
                    {
                        existe = false;
                        //Lo tengo que agregar
                    }
                  
                }
                if (existe == false)
                {
                    
                    Dictionary<string, object> resultProducto = BL.Producto.GetById(idProducto);
                    ML.Producto productoObj = (ML.Producto)resultProducto["Producto"];
                    productoObj.Cantidad = 1;
                    carrito.Productos.Add(productoObj);
                    HttpContext.Session.SetString("Carrito", Newtonsoft.Json.JsonConvert.SerializeObject(carrito.Productos));
                }
                else
                {
                    HttpContext.Session.SetString("Carrito", Newtonsoft.Json.JsonConvert.SerializeObject(carrito.Productos));
                }
                return RedirectToAction("Catalogo");
            }
          
        }
        [HttpGet]
        public ActionResult Carrito()
        {
            string productos = HttpContext.Session.GetString("Carrito");
            ML.Carrito carrito = new ML.Carrito();
            if (productos == null)
            {
                
                return View(carrito);
            }
            else
            {
                var ventaSession = Newtonsoft.Json.JsonConvert.DeserializeObject<List<object>>(HttpContext.Session.GetString("Carrito"));
                carrito.Productos = new List<object>();
                foreach (var obj in ventaSession)
                {
                    ML.Producto objProducto = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(obj.ToString());
                    carrito.Productos.Add(objProducto);
                }
                return View(carrito);
            }
           
        }
    }
}
