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
    public class DadosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dados
        public async Task<ActionResult> Index()
        {
            var dados = db.Dados.Include(d => d.Indicador);
            return View(await dados.ToListAsync());
        }

        // GET: Dados/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dados dados = await db.Dados.FindAsync(id);
            if (dados == null)
            {
                return HttpNotFound();
            }
            return View(dados);
        }

        // GET: Dados/Create
        public ActionResult Create()
        {
            ViewBag.IndicatorId = new SelectList(db.Indicators, "IndicatorId", "Name");
            return View();
        }

        // POST: Dados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IndicatorId,Ano,Valor")] Dados dados)
        {
            if (ModelState.IsValid)
            {
                db.Dados.Add(dados);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IndicatorId = new SelectList(db.Indicators, "IndicatorId", "Name", dados.IndicatorId);
            return View(dados);
        }

        // GET: Dados/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dados dados = await db.Dados.FindAsync(id);
            if (dados == null)
            {
                return HttpNotFound();
            }
            ViewBag.IndicatorId = new SelectList(db.Indicators, "IndicatorId", "Name", dados.IndicatorId);
            return View(dados);
        }

        // POST: Dados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IndicatorId,Ano,Valor")] Dados dados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dados).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IndicatorId = new SelectList(db.Indicators, "IndicatorId", "Name", dados.IndicatorId);
            return View(dados);
        }

        // GET: Dados/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dados dados = await db.Dados.FindAsync(id);
            if (dados == null)
            {
                return HttpNotFound();
            }
            return View(dados);
        }

        // POST: Dados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Dados dados = await db.Dados.FindAsync(id);
            db.Dados.Remove(dados);
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
