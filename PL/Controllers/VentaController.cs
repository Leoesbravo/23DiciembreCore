using Microsoft.AspNetCore.Mvc;
using ML;

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
            if(HttpContext.Session.GetString("Carrito") == null)
            {
                Dictionary<string, object> resultado = BL.Producto.GetById(idProducto);
                ML.Producto producto = (ML.Producto)resultado["Producto"];

                ML.Carrito carrito = new ML.Carrito();
                carrito.Productos = new List<object>();

                carrito.Productos.Add(producto);
                //Serializar el carrito
                //Crear una sesion
                HttpContext.Session.SetString("Carrito", Newtonsoft.Json.JsonConvert.SerializeObject(carrito.Productos));

                return RedirectToAction("Catalogo");
            }
            else
            {
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
