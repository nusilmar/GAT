using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GAT.Models;

namespace GAT.Controllers
{
    public class PrioridadesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prioridades
        public ActionResult Index()
        {
            return View(db.Prioridades.ToList());
        }

        // GET: Prioridades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prioridades prioridades = db.Prioridades.Find(id);
            if (prioridades == null)
            {
                return HttpNotFound();
            }
            return View(prioridades);
        }

        // GET: Prioridades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prioridades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Desc_Prioridade")] Prioridades prioridades)
        {
            if (ModelState.IsValid)
            {
                db.Prioridades.Add(prioridades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prioridades);
        }

        // GET: Prioridades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prioridades prioridades = db.Prioridades.Find(id);
            if (prioridades == null)
            {
                return HttpNotFound();
            }
            return View(prioridades);
        }

        // POST: Prioridades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Desc_Prioridade")] Prioridades prioridades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prioridades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prioridades);
        }

        // GET: Prioridades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prioridades prioridades = db.Prioridades.Find(id);
            if (prioridades == null)
            {
                return HttpNotFound();
            }
            return View(prioridades);
        }

        // POST: Prioridades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prioridades prioridades = db.Prioridades.Find(id);
            db.Prioridades.Remove(prioridades);
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
