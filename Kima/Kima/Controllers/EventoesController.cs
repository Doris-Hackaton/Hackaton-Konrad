using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kima;

namespace Kima.Controllers
{
    public class EventoesController : Controller
    {
        private KimaModelContainer db = new KimaModelContainer();

        // GET: Eventoes
        public ActionResult Index()
        {
            return View(db.Eventoes.ToList());
        }

        // GET: Eventoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventoes.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: Eventoes/Create
        public ActionResult Create()
        {
            EnfermedadsController enfermedadsController = new EnfermedadsController();
            ViewBag.enfermedades = enfermedadsController.getAllEnfermedades();
            ViewBag.medicinas = getAllMedicinas();
            ViewBag.centros = getAllCentros();
            return View();
        }

        // POST: Eventoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,color,doctor,anotaciones,fecha")] Evento evento, String Padecimiento, String Medicina, String CentroSalud)
        {
            if (ModelState.IsValid)
            {

                Enfermedad enf = getEnfermedadByName(Padecimiento);
                evento.Enfermedad = enf;
                Usuario u = db.Usuarios.Find(Session["idLoggead"]);
                evento.Usuario = u;

                if (Medicina != null) {
                    Medicinas medicina = getMedicinaByName(Medicina);
                    evento.Medicina = medicina;
                }
                if (CentroSalud != null) {
                    CentroSalud cs = getCentroByName(CentroSalud);
                    evento.CentroSalud = cs;
                }
                db.Eventoes.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(evento);
        }

        private Enfermedad getEnfermedadByName(string name)
        {
            Enfermedad enfermedad = db.Enfermedads.SingleOrDefault(e => e.nombre == name);
            return enfermedad;
        }
        private Medicinas getMedicinaByName(string name)
        {
            Medicinas med = db.Medicinas.FirstOrDefault(e => e.nombre == name);
            return med;
        }
        private List<string> getAllMedicinas()
        {
            List<Medicinas> medicinas = db.Medicinas.ToList();
            List<string> result = new List<string>();
            foreach (Medicinas med in medicinas)
            {
                result.Add(med.nombre);
            }
            return result;
        }
        private List<string> getAllCentros()
        {
            List<CentroSalud> centros = db.CentroSaluds.ToList();
            List<string> result = new List<string>();
            foreach (CentroSalud med in centros)
            {
                result.Add(med.nombre);
            }
            return result;
        }
        private CentroSalud getCentroByName(string name)
        {
            CentroSalud med = db.CentroSaluds.FirstOrDefault(e => e.nombre == name);
            return med;
        }


        // GET: Eventoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventoes.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Eventoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,color,doctor,anotaciones,fecha")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evento);
        }

        // GET: Eventoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventoes.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Eventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evento evento = db.Eventoes.Find(id);
            db.Eventoes.Remove(evento);
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
