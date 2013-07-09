using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrereslaAplicacionWeb.Controllers
{
    public class Default1Controller : Controller
    {
        private FreresdbEntities db = new FreresdbEntities();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View(db.clientes.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            clientes clientes = db.clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.clientes.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientes);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            clientes clientes = db.clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            clientes clientes = db.clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            clientes clientes = db.clientes.Find(id);
            db.clientes.Remove(clientes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}