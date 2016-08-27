using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Kima.Controllers
{
    public class EnfermedadsController : Controller
    {
        private KimaModelContainer db = new KimaModelContainer();

        // GET: Enfermedads
        public ActionResult Index()
        {
            return View(db.Enfermedads.ToList());
        }

        // GET: Enfermedads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enfermedad enfermedad = db.Enfermedads.Find(id);
            if (enfermedad == null)
            {
                return HttpNotFound();
            }
            return View(enfermedad);
        }

        // GET: Enfermedads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enfermedads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,fecha_diagnostico,ultimo_evento,tipo")] Enfermedad enfermedad)
        {
            if (ModelState.IsValid)
            {
                var id = Session["idLoggead"];
                db.Enfermedads.Add(enfermedad);
                enfermedad.Usuario = db.Usuarios.SingleOrDefault(u => u.id.ToString() == id.ToString());
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enfermedad);
        }

        // GET: Enfermedads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enfermedad enfermedad = db.Enfermedads.Find(id);
            if (enfermedad == null)
            {
                return HttpNotFound();
            }
            return View(enfermedad);
        }

        // POST: Enfermedads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,fecha_diagnostico,ultimo_evento,tipo")] Enfermedad enfermedad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enfermedad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enfermedad);
        }

        // GET: Enfermedads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enfermedad enfermedad = db.Enfermedads.Find(id);
            if (enfermedad == null)
            {
                return HttpNotFound();
            }
            return View(enfermedad);
        }

        // POST: Enfermedads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enfermedad enfermedad = db.Enfermedads.Find(id);
            db.Enfermedads.Remove(enfermedad);
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

        public Enfermedad getEnfermedadByName(string name)
        {
            Enfermedad enfermedad = db.Enfermedads.SingleOrDefault(e => e.nombre == name);
            return enfermedad;
        }

        public List<string> getAllEnfermedades()
        {
            List<Enfermedad> enfermedades = db.Enfermedads.ToList();
            List<string> result = new List<string>();
            foreach (Enfermedad enfermedad in enfermedades)
            {
                result.Add(enfermedad.nombre);
            }
            return result;
        }
    }
}
