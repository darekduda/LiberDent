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
    public class StanowiskaController : Controller
    {
        private readonly LiberDentContext _context;

        public StanowiskaController(LiberDentContext context)
        {
            _context = context;
        }

        // GET: Stanowiska
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stanowiska.ToListAsync());
        }

        // GET: Stanowiska/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stanowiska = await _context.Stanowiska
                .FirstOrDefaultAsync(m => m.IdStanowiska == id);
            if (stanowiska == null)
            {
                return NotFound();
            }

            return View(stanowiska);
        }

        // GET: Stanowiska/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stanowiska/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStanowiska,Nazwa,CzyStomatolog")] Stanowiska stanowiska)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stanowiska);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stanowiska);
        }

        // GET: Stanowiska/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stanowiska = await _context.Stanowiska.FindAsync(id);
            if (stanowiska == null)
            {
                return NotFound();
            }
            return View(stanowiska);
        }

        // POST: Stanowiska/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStanowiska,Nazwa,CzyStomatolog")] Stanowiska stanowiska)
        {
            if (id != stanowiska.IdStanowiska)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stanowiska);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StanowiskaExists(stanowiska.IdStanowiska))
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
            return View(stanowiska);
        }

        // GET: Stanowiska/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stanowiska = await _context.Stanowiska
                .FirstOrDefaultAsync(m => m.IdStanowiska == id);
            if (stanowiska == null)
            {
                return NotFound();
            }

            return View(stanowiska);
        }

        // POST: Stanowiska/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stanowiska = await _context.Stanowiska.FindAsync(id);
            _context.Stanowiska.Remove(stanowiska);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StanowiskaExists(int id)
        {
            return _context.Stanowiska.Any(e => e.IdStanowiska == id);
        }
    }
}
