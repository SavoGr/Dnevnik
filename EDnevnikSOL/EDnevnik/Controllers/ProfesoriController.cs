using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EDnevnik;

namespace EDnevnik.Controllers
{
    public class ProfesoriController : Controller
    {
        private DnevnikEntities db = new DnevnikEntities();

        // GET: Profesori
        public ActionResult Index()
        {
            return View(db.Profesoris.ToList());
        }

        // GET: Profesori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesori profesori = db.Profesoris.Find(id);
            if (profesori == null)
            {
                return HttpNotFound();
            }
            return View(profesori);
        }

        // GET: Profesori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profesori/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProfesora,Sifra,Ime,Prezime,IsAdmin")] Profesori profesori)
        {
            if (ModelState.IsValid)
            {
                db.Profesoris.Add(profesori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profesori);
        }

        // GET: Profesori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesori profesori = db.Profesoris.Find(id);
            if (profesori == null)
            {
                return HttpNotFound();
            }
            return View(profesori);
        }

        // POST: Profesori/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProfesora,Sifra,Ime,Prezime,IsAdmin")] Profesori profesori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profesori);
        }

        // GET: Profesori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesori profesori = db.Profesoris.Find(id);
            if (profesori == null)
            {
                return HttpNotFound();
            }
            return View(profesori);
        }

        // POST: Profesori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profesori profesori = db.Profesoris.Find(id);
            db.Profesoris.Remove(profesori);
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
