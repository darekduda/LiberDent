using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiberDent.Data.Data;
using LiberDent.Data.Data.Slownikowe;

namespace LiberDent.Intranet.Controllers
{
    public class RodzajeWizytyController : Controller
    {
        private readonly LiberDentContext _context;

        public RodzajeWizytyController(LiberDentContext context)
        {
            _context = context;
        }

        // GET: RodzajeWizyty
        public async Task<IActionResult> Index()
        {
            return View(await _context.RodzajeWizyty.ToListAsync());
        }

        // GET: RodzajeWizyty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rodzajeWizyty = await _context.RodzajeWizyty
                .FirstOrDefaultAsync(m => m.IdRodzajeWizyty == id);
            if (rodzajeWizyty == null)
            {
                return NotFound();
            }

            return View(rodzajeWizyty);
        }

        // GET: RodzajeWizyty/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RodzajeWizyty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRodzajeWizyty,Nazwa")] RodzajeWizyty rodzajeWizyty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rodzajeWizyty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rodzajeWizyty);
        }

        // GET: RodzajeWizyty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rodzajeWizyty = await _context.RodzajeWizyty.FindAsync(id);
            if (rodzajeWizyty == null)
            {
                return NotFound();
            }
            return View(rodzajeWizyty);
        }

        // POST: RodzajeWizyty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRodzajeWizyty,Nazwa")] RodzajeWizyty rodzajeWizyty)
        {
            if (id != rodzajeWizyty.IdRodzajeWizyty)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rodzajeWizyty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RodzajeWizytyExists(rodzajeWizyty.IdRodzajeWizyty))
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
            return View(rodzajeWizyty);
        }

        // GET: RodzajeWizyty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rodzajeWizyty = await _context.RodzajeWizyty
                .FirstOrDefaultAsync(m => m.IdRodzajeWizyty == id);
            if (rodzajeWizyty == null)
            {
                return NotFound();
            }

            return View(rodzajeWizyty);
        }

        // POST: RodzajeWizyty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rodzajeWizyty = await _context.RodzajeWizyty.FindAsync(id);
            _context.RodzajeWizyty.Remove(rodzajeWizyty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RodzajeWizytyExists(int id)
        {
            return _context.RodzajeWizyty.Any(e => e.IdRodzajeWizyty == id);
        }
    }
}
