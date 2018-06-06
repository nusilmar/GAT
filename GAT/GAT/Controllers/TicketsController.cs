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
    public class TicketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.Categoria).Include(t => t.Cliente).Include(t => t.Prioridade).Include(t => t.Status).Include(t => t.Tecnico).Include(t => t.Tipo);
            return View(tickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tickets tickets = db.Tickets.Find(id);
            if (tickets == null)
            {
                return HttpNotFound();
            }
            return View(tickets);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaFK = new SelectList(db.Categorias, "ID", "Categoria");
            ViewBag.ClienteFK = new SelectList(db.Clientes, "ID", "Nome");
            ViewBag.PrioridadeFK = new SelectList(db.Prioridades, "ID", "Desc_Prioridade");
            ViewBag.StatusFK = new SelectList(db.Estados, "ID", "Desc_Status");
            ViewBag.TecnicoFK = new SelectList(db.Tecnicos, "ID", "Nome");
            ViewBag.TipoFK = new SelectList(db.Tipos, "ID", "Desc_Tipo");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Problema,Descricao,TempoDispendido,DataAberturaTicket,DataFechoTicket,TecnicoFK,ClienteFK,CategoriaFK,StatusFK,TipoFK,PrioridadeFK")] Tickets tickets)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(tickets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaFK = new SelectList(db.Categorias, "ID", "Categoria", tickets.CategoriaFK);
            ViewBag.ClienteFK = new SelectList(db.Clientes, "ID", "Nome", tickets.ClienteFK);
            ViewBag.PrioridadeFK = new SelectList(db.Prioridades, "ID", "Desc_Prioridade", tickets.PrioridadeFK);
            ViewBag.StatusFK = new SelectList(db.Estados, "ID", "Desc_Status", tickets.StatusFK);
            ViewBag.TecnicoFK = new SelectList(db.Tecnicos, "ID", "Nome", tickets.TecnicoFK);
            ViewBag.TipoFK = new SelectList(db.Tipos, "ID", "Desc_Tipo", tickets.TipoFK);
            return View(tickets);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tickets tickets = db.Tickets.Find(id);
            if (tickets == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaFK = new SelectList(db.Categorias, "ID", "Categoria", tickets.CategoriaFK);
            ViewBag.ClienteFK = new SelectList(db.Clientes, "ID", "Nome", tickets.ClienteFK);
            ViewBag.PrioridadeFK = new SelectList(db.Prioridades, "ID", "Desc_Prioridade", tickets.PrioridadeFK);
            ViewBag.StatusFK = new SelectList(db.Estados, "ID", "Desc_Status", tickets.StatusFK);
            ViewBag.TecnicoFK = new SelectList(db.Tecnicos, "ID", "Nome", tickets.TecnicoFK);
            ViewBag.TipoFK = new SelectList(db.Tipos, "ID", "Desc_Tipo", tickets.TipoFK);
            return View(tickets);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Problema,Descricao,TempoDispendido,DataAberturaTicket,DataFechoTicket,TecnicoFK,ClienteFK,CategoriaFK,StatusFK,TipoFK,PrioridadeFK")] Tickets tickets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tickets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaFK = new SelectList(db.Categorias, "ID", "Categoria", tickets.CategoriaFK);
            ViewBag.ClienteFK = new SelectList(db.Clientes, "ID", "Nome", tickets.ClienteFK);
            ViewBag.PrioridadeFK = new SelectList(db.Prioridades, "ID", "Desc_Prioridade", tickets.PrioridadeFK);
            ViewBag.StatusFK = new SelectList(db.Estados, "ID", "Desc_Status", tickets.StatusFK);
            ViewBag.TecnicoFK = new SelectList(db.Tecnicos, "ID", "Nome", tickets.TecnicoFK);
            ViewBag.TipoFK = new SelectList(db.Tipos, "ID", "Desc_Tipo", tickets.TipoFK);
            return View(tickets);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tickets tickets = db.Tickets.Find(id);
            if (tickets == null)
            {
                return HttpNotFound();
            }
            return View(tickets);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tickets tickets = db.Tickets.Find(id);
            db.Tickets.Remove(tickets);
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
