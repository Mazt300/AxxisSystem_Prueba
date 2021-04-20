using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AxxisSystem.Model;
using AxxisSystem.Model.Modelo;

namespace AxxisSystem.Controllers
{
    public class Direccion_ContactoController : Controller
    {
        private AxxisSystemDbContext db = new AxxisSystemDbContext();

        // GET: Direccion_Contacto
        public ActionResult Index()
        {
            var direccion_Contactos = db.Direccion_Contactos.Include(d => d.Contacto).Include(d => d.Departamento);
            return View(direccion_Contactos.ToList());
        }

        // GET: Direccion_Contacto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion_Contacto direccion_Contacto = db.Direccion_Contactos.Find(id);
            if (direccion_Contacto == null)
            {
                return HttpNotFound();
            }
            return View(direccion_Contacto);
        }

        // GET: Direccion_Contacto/Create
        public ActionResult Create()
        {
            ViewBag.IdContacto = new SelectList(db.Contactos, "IdContacto", "Nombres");
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "NombreDepartamento");
            return View();
        }

        // POST: Direccion_Contacto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDireccion_Contacto,Direccion,IdDepartamento,IdContacto,Estado")] Direccion_Contacto direccion_Contacto)
        {
            if (ModelState.IsValid)
            {
                db.Direccion_Contactos.Add(direccion_Contacto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdContacto = new SelectList(db.Contactos, "IdContacto", "Nombres", direccion_Contacto.IdContacto);
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "NombreDepartamento", direccion_Contacto.IdDepartamento);
            return View(direccion_Contacto);
        }

        // GET: Direccion_Contacto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion_Contacto direccion_Contacto = db.Direccion_Contactos.Find(id);
            if (direccion_Contacto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdContacto = new SelectList(db.Contactos, "IdContacto", "Nombres", direccion_Contacto.IdContacto);
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "NombreDepartamento", direccion_Contacto.IdDepartamento);
            return View(direccion_Contacto);
        }

        // POST: Direccion_Contacto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDireccion_Contacto,Direccion,IdDepartamento,IdContacto,Estado")] Direccion_Contacto direccion_Contacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccion_Contacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdContacto = new SelectList(db.Contactos, "IdContacto", "Nombres", direccion_Contacto.IdContacto);
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "NombreDepartamento", direccion_Contacto.IdDepartamento);
            return View(direccion_Contacto);
        }

        // GET: Direccion_Contacto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion_Contacto direccion_Contacto = db.Direccion_Contactos.Find(id);
            if (direccion_Contacto == null)
            {
                return HttpNotFound();
            }
            return View(direccion_Contacto);
        }

        // POST: Direccion_Contacto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Direccion_Contacto direccion_Contacto = db.Direccion_Contactos.Find(id);
            db.Direccion_Contactos.Remove(direccion_Contacto);
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
