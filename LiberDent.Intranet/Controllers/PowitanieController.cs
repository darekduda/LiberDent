using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiberDent.Data.Data;
using LiberDent.Data.Data.CMS;

namespace LiberDent.Intranet.Controllers
{
    public class PowitanieController : Controller
    {
        private readonly LiberDentContext _context;

        public PowitanieController(LiberDentContext context)
        {
            _context = context;
        }

        // GET: Powitanie
        public async Task<IActionResult> Index()
        {
            return View(await _context.Powitanie.ToListAsync());
        }

        // GET: Powitanie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var powitanie = await _context.Powitanie
                .FirstOrDefaultAsync(m => m.IdPowitania == id);
            if (powitanie == null)
            {
                return NotFound();
            }

            return View(powitanie);
        }

        // GET: Powitanie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Powitanie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPowitania,NaglowekPowitalny,TrescPowitalna1,TrescPowitalna2,CzyAktywny")] Powitanie powitanie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(powitanie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(powitanie);
        }

        // GET: Powitanie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var powitanie = await _context.Powitanie.FindAsync(id);
            if (powitanie == null)
            {
                return NotFound();
            }
            return View(powitanie);
        }

        // POST: Powitanie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPowitania,NaglowekPowitalny,TrescPowitalna1,TrescPowitalna2,CzyAktywny")] Powitanie powitanie)
        {
            if (id != powitanie.IdPowitania)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(powitanie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PowitanieExists(powitanie.IdPowitania))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(powitanie);
        }

        // GET: Powitanie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var powitanie = await _context.Powitanie
                .FirstOrDefaultAsync(m => m.IdPowitania == id);
            if (powitanie == null)
            {
                return NotFound();
            }

            return View(powitanie);
        }

        // POST: Powitanie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var powitanie = await _context.Powitanie.FindAsync(id);
            _context.Powitanie.Remove(powitanie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PowitanieExists(int id)
        {
            return _context.Powitanie.Any(e => e.IdPowitania == id);
        }
    }
}
