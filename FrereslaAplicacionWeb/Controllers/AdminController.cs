using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FrereslaAplicacionWeb.Models;

namespace FrereslaAplicacionWeb.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index(string user,string nombre)
        {
            ViewBag.NombreCompleto = nombre;
            MenuLateralModels menulateral = new MenuLateralModels(user); 
            return View(menulateral);
        }

    }
}
