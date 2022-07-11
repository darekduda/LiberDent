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
    public class TytulNaukowyController : Controller
    {
        private readonly LiberDentContext _context;

        public TytulNaukowyController(LiberDentContext context)
        {
            _context = context;
        }

        // GET: TytulNaukowy
        public async Task<IActionResult> Index()
        {
            return View(await _context.TytulNaukowy.ToListAsync());
        }

        // GET: TytulNaukowy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tytulNaukowy = await _context.TytulNaukowy
                .FirstOrDefaultAsync(m => m.IdTytulNaukowy == id);
            if (tytulNaukowy == null)
            {
                return NotFound();
            }

            return View(tytulNaukowy);
        }

        // GET: TytulNaukowy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TytulNaukowy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTytulNaukowy,Nazwa,Skrot")] TytulNaukowy tytulNaukowy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tytulNaukowy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tytulNaukowy);
        }

        // GET: TytulNaukowy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tytulNaukowy = await _context.TytulNaukowy.FindAsync(id);
            if (tytulNaukowy == null)
            {
                return NotFound();
            }
            return View(tytulNaukowy);
        }

        // POST: TytulNaukowy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTytulNaukowy,Nazwa,Skrot")] TytulNaukowy tytulNaukowy)
        {
            if (id != tytulNaukowy.IdTytulNaukowy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tytulNaukowy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TytulNaukowyExists(tytulNaukowy.IdTytulNaukowy))
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
            return View(tytulNaukowy);
        }

        // GET: TytulNaukowy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tytulNaukowy = await _context.TytulNaukowy
                .FirstOrDefaultAsync(m => m.IdTytulNaukowy == id);
            if (tytulNaukowy == null)
            {
                return NotFound();
            }

            return View(tytulNaukowy);
        }

        // POST: TytulNaukowy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tytulNaukowy = await _context.TytulNaukowy.FindAsync(id);
            _context.TytulNaukowy.Remove(tytulNaukowy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TytulNaukowyExists(int id)
        {
            return _context.TytulNaukowy.Any(e => e.IdTytulNaukowy == id);
        }
    }
}
