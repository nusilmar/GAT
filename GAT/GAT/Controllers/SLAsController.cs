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
    public class SLAsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SLAs
        public ActionResult Index()
        {
            return View(db.SLAs.ToList());
        }

        // GET: SLAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLAs sLAs = db.SLAs.Find(id);
            if (sLAs == null)
            {
                return HttpNotFound();
            }
            return View(sLAs);
        }

        // GET: SLAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SLAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SLA_Desc,horas")] SLAs sLAs)
        {
            if (ModelState.IsValid)
            {
                db.SLAs.Add(sLAs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sLAs);
        }

        // GET: SLAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLAs sLAs = db.SLAs.Find(id);
            if (sLAs == null)
            {
                return HttpNotFound();
            }
            return View(sLAs);
        }

        // POST: SLAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SLA_Desc,horas")] SLAs sLAs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sLAs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sLAs);
        }

        // GET: SLAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLAs sLAs = db.SLAs.Find(id);
            if (sLAs == null)
            {
                return HttpNotFound();
            }
            return View(sLAs);
        }

        // POST: SLAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SLAs sLAs = db.SLAs.Find(id);
            db.SLAs.Remove(sLAs);
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
