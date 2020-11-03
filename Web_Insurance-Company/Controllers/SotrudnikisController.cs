using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Insurance_Company.Data;
using Insurance_Company.Models;

namespace Web_Insurance_Company.Controllers
{
    public class SotrudnikisController : Controller
    {
        private readonly InsuranceCompanyContext _context;

        public SotrudnikisController(InsuranceCompanyContext context)
        {
            _context = context;
        }

        // GET: Sotrudnikis
        public async Task<IActionResult> Index()
        {
            var insuranceCompanyContext = _context.Sotrudniki.Include(s => s.KodDolzhnostiNavigation);
            return View(await insuranceCompanyContext.ToListAsync());
        }

        // GET: Sotrudnikis/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sotrudniki = await _context.Sotrudniki
                .Include(s => s.KodDolzhnostiNavigation)
                .FirstOrDefaultAsync(m => m.KodSotrudnika == id);
            if (sotrudniki == null)
            {
                return NotFound();
            }

            return View(sotrudniki);
        }

        // GET: Sotrudnikis/Create
        public IActionResult Create()
        {
            ViewData["KodDolzhnosti"] = new SelectList(_context.Dolzhnosti, "KodDolzhnosti", "NaimenovanieDolzhnosti");
            return View();
        }

        // POST: Sotrudnikis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KodSotrudnika,Fio,DataRozdeniya,Pol,Adres,Telefon,PasportnyeDannye,KodDolzhnosti")] Sotrudniki sotrudniki)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sotrudniki);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KodDolzhnosti"] = new SelectList(_context.Dolzhnosti, "KodDolzhnosti", "NaimenovanieDolzhnosti", sotrudniki.KodDolzhnosti);
            return View(sotrudniki);
        }

        // GET: Sotrudnikis/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sotrudniki = await _context.Sotrudniki.FindAsync(id);
            if (sotrudniki == null)
            {
                return NotFound();
            }
            ViewData["KodDolzhnosti"] = new SelectList(_context.Dolzhnosti, "KodDolzhnosti", "NaimenovanieDolzhnosti", sotrudniki.KodDolzhnosti);
            return View(sotrudniki);
        }

        // POST: Sotrudnikis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("KodSotrudnika,Fio,DataRozdeniya,Pol,Adres,Telefon,PasportnyeDannye,KodDolzhnosti")] Sotrudniki sotrudniki)
        {
            if (id != sotrudniki.KodSotrudnika)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sotrudniki);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SotrudnikiExists(sotrudniki.KodSotrudnika))
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
            ViewData["KodDolzhnosti"] = new SelectList(_context.Dolzhnosti, "KodDolzhnosti", "NaimenovanieDolzhnosti", sotrudniki.KodDolzhnosti);
            return View(sotrudniki);
        }

        // GET: Sotrudnikis/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sotrudniki = await _context.Sotrudniki
                .Include(s => s.KodDolzhnostiNavigation)
                .FirstOrDefaultAsync(m => m.KodSotrudnika == id);
            if (sotrudniki == null)
            {
                return NotFound();
            }

            return View(sotrudniki);
        }

        // POST: Sotrudnikis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var sotrudniki = await _context.Sotrudniki.FindAsync(id);
            _context.Sotrudniki.Remove(sotrudniki);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SotrudnikiExists(long id)
        {
            return _context.Sotrudniki.Any(e => e.KodSotrudnika == id);
        }
    }
}
