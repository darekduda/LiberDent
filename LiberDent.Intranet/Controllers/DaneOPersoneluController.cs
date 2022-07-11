using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiberDent.Data.Data;
using LiberDent.Data.Data.CMS;
using LiberDent.Intranet.Models;

namespace LiberDent.Intranet.Controllers
{
    public class DaneOPersoneluController : Controller
    {
        private readonly LiberDentContext _context;

        public DaneOPersoneluController(LiberDentContext context)
        {
            _context = context;
        }

        // GET: DaneOPersonelu
        public async Task<IActionResult> Index()
        {
            var model = await _context.DaneOPersonelu.ToListAsync();
            foreach(var item in model)
            {
                item.TytulNaukowy = await _context.TytulNaukowy.FindAsync(item.IdTytulNaukowy);
                item.Stanowiska = await _context.Stanowiska.FindAsync(item.IdStanowiska);
            }
            return View(model);
        }

        // GET: DaneOPersonelu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daneOPersonelu = await _context.DaneOPersonelu
                .FirstOrDefaultAsync(m => m.IdDaneOPersonelu == id);
            if (daneOPersonelu == null)
            {
                return NotFound();
            }
            daneOPersonelu.TytulNaukowy = await _context.TytulNaukowy.FindAsync(daneOPersonelu.IdTytulNaukowy);
            daneOPersonelu.Stanowiska = await _context.Stanowiska.FindAsync(daneOPersonelu.IdStanowiska);

            return View(daneOPersonelu);
        }

        // GET: DaneOPersonelu/Create
        public IActionResult Create()
        {
            var model = new DaneOPersoneluViewModel()
            {
                DaneOPersonelu = new DaneOPersonelu(),
                TytulyNaukowe = _context.TytulNaukowy.ToList(),
                Stanowiska = _context.Stanowiska.ToList()
            };
            return View(model);
        }

        // POST: DaneOPersonelu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDaneOPersonelu,Imie,Nazwisko,Zdjecie,Opis,IdTytulNaukowy,IdStanowiska")] DaneOPersonelu daneOPersonelu)
        {
            if (ModelState.IsValid)
            {

                _context.Add(daneOPersonelu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(daneOPersonelu);
        }

        // GET: DaneOPersonelu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = new DaneOPersoneluViewModel()
            {
                DaneOPersonelu = await _context.DaneOPersonelu.FindAsync(id),
                Stanowiska = await _context.Stanowiska.ToListAsync(),
                TytulyNaukowe = await _context.TytulNaukowy.ToListAsync()
            };
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: DaneOPersonelu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDaneOPersonelu,Imie,Nazwisko,Zdjecie,Opis,IdTytulNaukowy,IdStanowiska")] DaneOPersonelu daneOPersonelu)
        {
            if (id != daneOPersonelu.IdDaneOPersonelu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(daneOPersonelu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DaneOPersoneluExists(daneOPersonelu.IdDaneOPersonelu))
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
            return View(daneOPersonelu);
        }

        // GET: DaneOPersonelu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daneOPersonelu = await _context.DaneOPersonelu
                .FirstOrDefaultAsync(m => m.IdDaneOPersonelu == id);
            if (daneOPersonelu == null)
            {
                return NotFound();
            }

            return View(daneOPersonelu);
        }

        // POST: DaneOPersonelu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var daneOPersonelu = await _context.DaneOPersonelu.FindAsync(id);
            _context.DaneOPersonelu.Remove(daneOPersonelu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DaneOPersoneluExists(int id)
        {
            return _context.DaneOPersonelu.Any(e => e.IdDaneOPersonelu == id);
        }
    }
}
