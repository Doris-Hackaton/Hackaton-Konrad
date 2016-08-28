using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Kima.Controllers
{
    public class MedicinasController : Controller
    {
        private KimaModelContainer db = new KimaModelContainer();

        // GET: Medicinas
        public ActionResult Index()
        {
            if (Session["idLoggead"] == null)
                return View("~/Views/Login/Login.cshtml");
            int id = Int32.Parse(Session["idLoggead"].ToString());

            List<Medicinas> medicinasLista = db.Medicinas.Where(e => e.Usuario.id == id).ToList();
            return View(medicinasLista);
        }

        // GET: Medicinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicinas medicinas = db.Medicinas.Find(id);
            if (medicinas == null)
            {
                return HttpNotFound();
            }
            return View(medicinas);
        }

        // GET: Medicinas/Create
        public ActionResult Create()
        {
            if (Session["idLoggead"] == null)
                return View("~/Views/Login/Login.cshtml");
            EnfermedadsController enfermedadsController = new EnfermedadsController();
            ViewBag.enfermedades = enfermedadsController.getAllEnfermedades();
            return View();
        }

        // POST: Medicinas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,detalles,dosis,frecuencia,tipo,info_compra")] Medicinas medicinas)
        {
            if (Session["idLoggead"] == null)
                return View("~/Views/Login/Login.cshtml");
            if (ModelState.IsValid)
            {
                Usuario u = db.Usuarios.Find(Session["idLoggead"]);
                medicinas.Usuario = u;
                db.Medicinas.Add(medicinas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicinas);
        }

        // GET: Medicinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["idLoggead"] == null)
                return View("~/Views/Login/Login.cshtml");
            EnfermedadsController enfermedadsController = new EnfermedadsController();
            ViewBag.enfermedades = enfermedadsController.getAllEnfermedades();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicinas medicinas = db.Medicinas.Find(id);
            if (medicinas == null)
            {
                return HttpNotFound();
            }
            return View(medicinas);
        }

        // POST: Medicinas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,detalles,dosis,frecuencia,tipo,info_compra")] Medicinas medicinas)
        {
            if (Session["idLoggead"] == null)
                return View("~/Views/Login/Login.cshtml");
            if (ModelState.IsValid)
            {
                db.Entry(medicinas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicinas);
        }


        // POST: Medicinas/Delete/5
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string nombre)
        {
            if (Session["idLoggead"] == null)
                return View("~/Views/Login/Login.cshtml");
            Medicinas medicinas = db.Medicinas.SingleOrDefault(medicina => medicina.nombre == nombre);
            db.Medicinas.Remove(medicinas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
