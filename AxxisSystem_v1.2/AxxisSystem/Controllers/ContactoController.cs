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
using AxxisSystem.Servicios.Servicios;

namespace AxxisSystem.Controllers
{
    public class ContactoController : Controller
    {
        ContactoService ctsv = new ContactoService();

        // GET: Contacto
        public ActionResult Index()
        {
            return View(ctsv.TodosLosContactosActivos());
        }

        // GET: Contacto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = ctsv.ObtenerContactoXId(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contacto contacto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ctsv.GuardarContacto(contacto) == true)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(contacto);
            }
            catch { return View(contacto); }
        }

        // GET: Contacto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = ctsv.ObtenerContactoXId(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // POST: Contacto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                if (ctsv.EditarContacto(contacto) == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(contacto);
        }

        // GET: Contacto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id > 0)
            {
                ctsv.EliminarContacto(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // POST: Contacto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (id > 0)
            {
                ctsv.EliminarContacto(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
