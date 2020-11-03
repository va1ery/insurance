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
    public class VidyPolisovsController : Controller
    {
        private readonly InsuranceCompanyContext _context;

        public VidyPolisovsController(InsuranceCompanyContext context)
        {
            _context = context;
        }

        // GET: VidyPolisovs
        public async Task<IActionResult> Index()
        {
            var insuranceCompanyContext = _context.VidyPolisov.Include(v => v.KodRiskaNavigation);
            return View(await insuranceCompanyContext.ToListAsync());
        }

        // GET: VidyPolisovs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vidyPolisov = await _context.VidyPolisov
                .Include(v => v.KodRiskaNavigation)
                .FirstOrDefaultAsync(m => m.KodVidaPolisa == id);
            if (vidyPolisov == null)
            {
                return NotFound();
            }

            return View(vidyPolisov);
        }

        // GET: VidyPolisovs/Create
        public IActionResult Create()
        {
            ViewData["KodRiska"] = new SelectList(_context.Riski, "KodRiska", "Naimenovanie");
            return View();
        }

        // POST: VidyPolisovs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KodVidaPolisa,Naimenovanie,Opisanie,Usloviya,KodRiska")] VidyPolisov vidyPolisov)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vidyPolisov);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KodRiska"] = new SelectList(_context.Riski, "KodRiska", "Naimenovanie", vidyPolisov.KodRiska);
            return View(vidyPolisov);
        }

        // GET: VidyPolisovs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vidyPolisov = await _context.VidyPolisov.FindAsync(id);
            if (vidyPolisov == null)
            {
                return NotFound();
            }
            ViewData["KodRiska"] = new SelectList(_context.Riski, "KodRiska", "Naimenovanie", vidyPolisov.KodRiska);
            return View(vidyPolisov);
        }

        // POST: VidyPolisovs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("KodVidaPolisa,Naimenovanie,Opisanie,Usloviya,KodRiska")] VidyPolisov vidyPolisov)
        {
            if (id != vidyPolisov.KodVidaPolisa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vidyPolisov);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VidyPolisovExists(vidyPolisov.KodVidaPolisa))
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
            ViewData["KodRiska"] = new SelectList(_context.Riski, "KodRiska", "Naimenovanie", vidyPolisov.KodRiska);
            return View(vidyPolisov);
        }

        // GET: VidyPolisovs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vidyPolisov = await _context.VidyPolisov
                .Include(v => v.KodRiskaNavigation)
                .FirstOrDefaultAsync(m => m.KodVidaPolisa == id);
            if (vidyPolisov == null)
            {
                return NotFound();
            }

            return View(vidyPolisov);
        }

        // POST: VidyPolisovs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var vidyPolisov = await _context.VidyPolisov.FindAsync(id);
            _context.VidyPolisov.Remove(vidyPolisov);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VidyPolisovExists(long id)
        {
            return _context.VidyPolisov.Any(e => e.KodVidaPolisa == id);
        }
    }
}
