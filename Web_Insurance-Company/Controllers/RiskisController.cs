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
    public class RiskisController : Controller
    {
        private readonly InsuranceCompanyContext _context;

        public RiskisController(InsuranceCompanyContext context)
        {
            _context = context;
        }

        // GET: Riskis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Riski.ToListAsync());
        }

        // GET: Riskis/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var riski = await _context.Riski
                .FirstOrDefaultAsync(m => m.KodRiska == id);
            if (riski == null)
            {
                return NotFound();
            }

            return View(riski);
        }

        // GET: Riskis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Riskis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KodRiska,Naimenovanie,Opisanie,SrednyayaVeroyatnost")] Riski riski)
        {
            if (ModelState.IsValid)
            {
                _context.Add(riski);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(riski);
        }

        // GET: Riskis/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var riski = await _context.Riski.FindAsync(id);
            if (riski == null)
            {
                return NotFound();
            }
            return View(riski);
        }

        // POST: Riskis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("KodRiska,Naimenovanie,Opisanie,SrednyayaVeroyatnost")] Riski riski)
        {
            if (id != riski.KodRiska)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(riski);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RiskiExists(riski.KodRiska))
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
            return View(riski);
        }

        // GET: Riskis/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var riski = await _context.Riski
                .FirstOrDefaultAsync(m => m.KodRiska == id);
            if (riski == null)
            {
                return NotFound();
            }

            return View(riski);
        }

        // POST: Riskis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var riski = await _context.Riski.FindAsync(id);
            _context.Riski.Remove(riski);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RiskiExists(long id)
        {
            return _context.Riski.Any(e => e.KodRiska == id);
        }
    }
}
