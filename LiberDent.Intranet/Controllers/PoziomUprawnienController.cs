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
    public class PoziomUprawnienController : Controller
    {
        private readonly LiberDentContext _context;

        public PoziomUprawnienController(LiberDentContext context)
        {
            _context = context;
        }

        // GET: PoziomUprawnien
        public async Task<IActionResult> Index()
        {
            return View(await _context.PoziomUprawnien.ToListAsync());
        }

        // GET: PoziomUprawnien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poziomUprawnien = await _context.PoziomUprawnien
                .FirstOrDefaultAsync(m => m.IdPoziomUprawnien == id);
            if (poziomUprawnien == null)
            {
                return NotFound();
            }

            return View(poziomUprawnien);
        }

        // GET: PoziomUprawnien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PoziomUprawnien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPoziomUprawnien,NumerUprawnien,OpisUprawnien")] PoziomUprawnien poziomUprawnien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poziomUprawnien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(poziomUprawnien);
        }

        // GET: PoziomUprawnien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poziomUprawnien = await _context.PoziomUprawnien.FindAsync(id);
            if (poziomUprawnien == null)
            {
                return NotFound();
            }
            return View(poziomUprawnien);
        }

        // POST: PoziomUprawnien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPoziomUprawnien,NumerUprawnien,OpisUprawnien")] PoziomUprawnien poziomUprawnien)
        {
            if (id != poziomUprawnien.IdPoziomUprawnien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poziomUprawnien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoziomUprawnienExists(poziomUprawnien.IdPoziomUprawnien))
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
            return View(poziomUprawnien);
        }

        // GET: PoziomUprawnien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poziomUprawnien = await _context.PoziomUprawnien
                .FirstOrDefaultAsync(m => m.IdPoziomUprawnien == id);
            if (poziomUprawnien == null)
            {
                return NotFound();
            }

            return View(poziomUprawnien);
        }

        // POST: PoziomUprawnien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var poziomUprawnien = await _context.PoziomUprawnien.FindAsync(id);
            _context.PoziomUprawnien.Remove(poziomUprawnien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoziomUprawnienExists(int id)
        {
            return _context.PoziomUprawnien.Any(e => e.IdPoziomUprawnien == id);
        }
    }
}
