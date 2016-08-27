using System;
using System.Linq;
using System.Web.Mvc;

namespace Kima.Controllers
{
    public class LoginController : Controller
    {
        private KimaModelContainer db = new KimaModelContainer();





        // GET: Usuarios/Create
        public ActionResult Logout()
        {
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Login()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "id,email,password,nombre,edad,domicilio,proced_quirurgico,cedula")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario usuarioConsultado = db.Usuarios.SingleOrDefault(user => user.email == usuario.email);

                String correo = usuario.email;
                String password = usuario.password;
                String correoConsultado = "";
                String passwordConsultado = "";

                if (usuarioConsultado != null)
                {
                    int id = usuarioConsultado.id;
                    Session["idLoggead"] = id;
                    correoConsultado = usuarioConsultado.email;
                    passwordConsultado = usuarioConsultado.password;
                }
                bool log = false;

                if (correo != correoConsultado)
                {
                    ModelState.AddModelError("errorCorreo", "El correo ingresado es incorrecto.");
                }
                else
                {
                    if (password != passwordConsultado)
                    {
                        ModelState.AddModelError("errorPassword", "La contraseña ingresada es incorrecta.");
                    }
                    else
                    {
                        log = true;
                    }
                }

                if (log)
                {
                    return Redirect("~");
                }

            }

            return View(usuario);
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
