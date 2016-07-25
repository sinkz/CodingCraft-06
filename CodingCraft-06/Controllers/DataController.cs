using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodingCraft_06.Models;
using IdentitySample.Models;

namespace CodingCraft_06.Controllers
{
    public class DataController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Data
        public async Task<ActionResult> Index()
        {
            var data = db.Data.Include(d => d.RelatedIndicator);
            return View(await data.ToListAsync());
        }

        // GET: Data/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data data = await db.Data.FindAsync(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // GET: Data/Create
        public ActionResult Create()
        {
            ViewBag.RelatedIndicatorId = new SelectList(db.Indicators, "IndicatorId", "Name");
            return View();
        }

        // POST: Data/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DataId,RelatedIndicatorId,Country,Indicator,Year,Value")] Data data)
        {
            if (ModelState.IsValid)
            {
                db.Data.Add(data);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RelatedIndicatorId = new SelectList(db.Indicators, "IndicatorId", "Name", data.RelatedIndicatorId);
            return View(data);
        }

        // GET: Data/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data data = await db.Data.FindAsync(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            ViewBag.RelatedIndicatorId = new SelectList(db.Indicators, "IndicatorId", "Name", data.RelatedIndicatorId);
            return View(data);
        }

        // POST: Data/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DataId,RelatedIndicatorId,Country,Indicator,Year,Value")] Data data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(data).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RelatedIndicatorId = new SelectList(db.Indicators, "IndicatorId", "Name", data.RelatedIndicatorId);
            return View(data);
        }

        // GET: Data/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data data = await db.Data.FindAsync(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Data data = await db.Data.FindAsync(id);
            db.Data.Remove(data);
            await db.SaveChangesAsync();
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
