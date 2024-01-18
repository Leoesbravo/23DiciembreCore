using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario("","","");
            Dictionary<string, object> result = BL.Usuario.GetAll(usuario);
            usuario = (ML.Usuario)result["Usuario"];
            return View(usuario);
        }
    }
}
