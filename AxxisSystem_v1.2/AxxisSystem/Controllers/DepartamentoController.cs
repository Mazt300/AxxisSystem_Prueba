using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using AxxisSystem.Model;
using AxxisSystem.Model.Modelo;
using AxxisSystem.Servicios;

namespace AxxisSystem.Controllers
{
    public class DepartamentoController : Controller
    {
        DepartamentoService dpsv = new DepartamentoService();

        // GET: Departamento
        public ActionResult Index()
        {
            return View(dpsv.TodosLosDepartamentosActivos());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento contacto = dpsv.Obtener_DepartamentoxId(id);
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
        public ActionResult Create(Departamento departamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (dpsv.GuardarDepartamento(departamento) == true)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(departamento);
            }
            catch { return View(departamento); }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = dpsv.Obtener_DepartamentoxId(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Departamento departamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (dpsv.EditarDepartamento(departamento) == true)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(departamento);
            }
            catch { return View(departamento); }
        }

        public ActionResult Delete(int? id)
        {
           
            if (id > 0)
            {
                dpsv.EliminarDepartamento(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // POST: Departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (id > 0)
            {
                dpsv.EliminarDepartamento(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
