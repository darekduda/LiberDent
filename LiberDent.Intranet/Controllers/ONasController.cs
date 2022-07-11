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
    public class ONasController : Controller
    {
        private readonly LiberDentContext _context;

        public ONasController(LiberDentContext context)
        {
            _context = context;
        }

        // GET: ONas
        public async Task<IActionResult> Index()
        {
            return View(await _context.ONas.ToListAsync());
        }

        // GET: ONas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oNas = await _context.ONas
                .FirstOrDefaultAsync(m => m.IdONas == id);
            if (oNas == null)
            {
                return NotFound();
            }

            return View(oNas);
        }

        // GET: ONas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ONas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdONas,Naglowek,Tresc1,Tresc2")] ONas oNas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oNas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oNas);
        }

        // GET: ONas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oNas = await _context.ONas.FindAsync(id);
            if (oNas == null)
            {
                return NotFound();
            }
            return View(oNas);
        }

        // POST: ONas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdONas,Naglowek,Tresc1,Tresc2")] ONas oNas)
        {
            if (id != oNas.IdONas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oNas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ONasExists(oNas.IdONas))
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
            return View(oNas);
        }

        // GET: ONas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oNas = await _context.ONas
                .FirstOrDefaultAsync(m => m.IdONas == id);
            if (oNas == null)
            {
                return NotFound();
            }

            return View(oNas);
        }

        // POST: ONas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oNas = await _context.ONas.FindAsync(id);
            _context.ONas.Remove(oNas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ONasExists(int id)
        {
            return _context.ONas.Any(e => e.IdONas == id);
        }
    }
}
