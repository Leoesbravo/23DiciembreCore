using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario("", "", "");
            Dictionary<string, object> result = BL.Usuario.GetAll(usuario);
            usuario = (ML.Usuario)result["Usuario"];
            
            return View(usuario);
        }
        [HttpGet]
        public ActionResult Form()
        {
            ML.Usuario usuario = new ML.Usuario();
            return View(usuario);
        }
        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            IFormFile file = Request.Form.Files["amd"];
            if(file != null)
            {
                usuario.Imagen = ConvertToBytes(file);
                Dictionary<string, object> resultado = BL.Usuario.Add(usuario);

                bool result = (bool)resultado["Resultado"];
                if(result )
                {
                    return PartialView("Modal");
                }
            }
            else
            {

            }
            return View(usuario);
        }
        //[HttpPost]
        //public JsonResult ChangeStatus(int idUsuario,bool estado)
        //{
        //    Dictionary<string, object> resultado  = BL.Usuario.ChangeStatus(idUsuario,estado);
        //    bool result = (bool)resultado["Resultado"];
        //    return Json(result);
        //}
        public byte[] ConvertToBytes(IFormFile foto)
        {
            using var fileStream = foto.OpenReadStream();

            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }
    }
}
