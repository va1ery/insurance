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
    public class PolisiesController : Controller
    {
        private readonly InsuranceCompanyContext _context;

        public PolisiesController(InsuranceCompanyContext context)
        {
            _context = context;
        }

        // GET: Polisies
        public async Task<IActionResult> Index()
        {
            var insuranceCompanyContext = _context.Polisy.Include(p => p.KodKlientaNavigation).Include(p => p.KodSotrudnikaNavigation).Include(p => p.KodVidaPolisaNavigation);
            return View(await insuranceCompanyContext.ToListAsync());
        }

        // GET: Polisies/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var polisy = await _context.Polisy
                .Include(p => p.KodKlientaNavigation)
                .Include(p => p.KodSotrudnikaNavigation)
                .Include(p => p.KodVidaPolisaNavigation)
                .FirstOrDefaultAsync(m => m.NomerPolisa == id);
            if (polisy == null)
            {
                return NotFound();
            }

            return View(polisy);
        }

        // GET: Polisies/Create
        public IActionResult Create()
        {
            ViewData["KodKlienta"] = new SelectList(_context.Klienty, "KodKlienta", "Adres");
            ViewData["KodSotrudnika"] = new SelectList(_context.Sotrudniki, "KodSotrudnika", "Adres");
            ViewData["KodVidaPolisa"] = new SelectList(_context.VidyPolisov, "KodVidaPolisa", "Naimenovanie");
            return View();
        }

        // POST: Polisies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomerPolisa,DataNachala,DataOkonchaniya,Stoimost,SummaVyplaty,OtmetkaOVyplate,OtmetkaObOkonchanii,KodVidaPolisa,KodKlienta,KodSotrudnika")] Polisy polisy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(polisy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KodKlienta"] = new SelectList(_context.Klienty, "KodKlienta", "Adres", polisy.KodKlienta);
            ViewData["KodSotrudnika"] = new SelectList(_context.Sotrudniki, "KodSotrudnika", "Adres", polisy.KodSotrudnika);
            ViewData["KodVidaPolisa"] = new SelectList(_context.VidyPolisov, "KodVidaPolisa", "Naimenovanie", polisy.KodVidaPolisa);
            return View(polisy);
        }

        // GET: Polisies/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var polisy = await _context.Polisy.FindAsync(id);
            if (polisy == null)
            {
                return NotFound();
            }
            ViewData["KodKlienta"] = new SelectList(_context.Klienty, "KodKlienta", "Adres", polisy.KodKlienta);
            ViewData["KodSotrudnika"] = new SelectList(_context.Sotrudniki, "KodSotrudnika", "Adres", polisy.KodSotrudnika);
            ViewData["KodVidaPolisa"] = new SelectList(_context.VidyPolisov, "KodVidaPolisa", "Naimenovanie", polisy.KodVidaPolisa);
            return View(polisy);
        }

        // POST: Polisies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("NomerPolisa,DataNachala,DataOkonchaniya,Stoimost,SummaVyplaty,OtmetkaOVyplate,OtmetkaObOkonchanii,KodVidaPolisa,KodKlienta,KodSotrudnika")] Polisy polisy)
        {
            if (id != polisy.NomerPolisa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(polisy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolisyExists(polisy.NomerPolisa))
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
            ViewData["KodKlienta"] = new SelectList(_context.Klienty, "KodKlienta", "Adres", polisy.KodKlienta);
            ViewData["KodSotrudnika"] = new SelectList(_context.Sotrudniki, "KodSotrudnika", "Adres", polisy.KodSotrudnika);
            ViewData["KodVidaPolisa"] = new SelectList(_context.VidyPolisov, "KodVidaPolisa", "Naimenovanie", polisy.KodVidaPolisa);
            return View(polisy);
        }

        // GET: Polisies/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var polisy = await _context.Polisy
                .Include(p => p.KodKlientaNavigation)
                .Include(p => p.KodSotrudnikaNavigation)
                .Include(p => p.KodVidaPolisaNavigation)
                .FirstOrDefaultAsync(m => m.NomerPolisa == id);
            if (polisy == null)
            {
                return NotFound();
            }

            return View(polisy);
        }

        // POST: Polisies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var polisy = await _context.Polisy.FindAsync(id);
            _context.Polisy.Remove(polisy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PolisyExists(long id)
        {
            return _context.Polisy.Any(e => e.NomerPolisa == id);
        }
    }
}
