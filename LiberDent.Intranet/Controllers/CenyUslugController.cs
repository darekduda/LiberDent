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
    public class CenyUslugController : Controller
    {
        private readonly LiberDentContext _context;

        public CenyUslugController(LiberDentContext context)
        {
            _context = context;
        }

        // GET: CenyUslug
        public async Task<IActionResult> Index()
        {
            return View(await _context.CenyUslug.ToListAsync());
        }

        // GET: CenyUslug/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cenyUslug = await _context.CenyUslug
                .FirstOrDefaultAsync(m => m.IdCenyUslug == id);
            if (cenyUslug == null)
            {
                return NotFound();
            }

            return View(cenyUslug);
        }

        // GET: CenyUslug/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CenyUslug/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCenyUslug,NazwaUslugi,CenaUslugi")] CenyUslug cenyUslug)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cenyUslug);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cenyUslug);
        }

        // GET: CenyUslug/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cenyUslug = await _context.CenyUslug.FindAsync(id);
            if (cenyUslug == null)
            {
                return NotFound();
            }
            return View(cenyUslug);
        }

        // POST: CenyUslug/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCenyUslug,NazwaUslugi,CenaUslugi")] CenyUslug cenyUslug)
        {
            if (id != cenyUslug.IdCenyUslug)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cenyUslug);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CenyUslugExists(cenyUslug.IdCenyUslug))
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
            return View(cenyUslug);
        }

        // GET: CenyUslug/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cenyUslug = await _context.CenyUslug
                .FirstOrDefaultAsync(m => m.IdCenyUslug == id);
            if (cenyUslug == null)
            {
                return NotFound();
            }

            return View(cenyUslug);
        }

        // POST: CenyUslug/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cenyUslug = await _context.CenyUslug.FindAsync(id);
            _context.CenyUslug.Remove(cenyUslug);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CenyUslugExists(int id)
        {
            return _context.CenyUslug.Any(e => e.IdCenyUslug == id);
        }
    }
}
