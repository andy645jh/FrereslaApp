using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrereslaAplicacionWeb.Models;
using System.Web.Security;
namespace FrereslaAplicacionWeb.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            LoginModel usuario=new LoginModel();

            //verificar si el usuario ingresado es correto
            if (ModelState.IsValid)
            {
                if(usuario.validarUsuario(model.UserName,model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("../Admin", new  { user = usuario.UserName,nombre=usuario.NombreCompleto });
                }
            }
            else
            {
                ModelState.AddModelError("","Usuario o Contraseña Invalidos");
            }
            return View();
        }
    }
}
