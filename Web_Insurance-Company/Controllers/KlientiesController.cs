using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Insurance_Company.Data;
using Insurance_Company.Models;

namespace Web_Insurance_Company.Controllers
{
    public class KlientiesController : Controller
    {
        private readonly InsuranceCompanyContext _context;

        public KlientiesController(InsuranceCompanyContext context)
        {
            _context = context;
        }

        // GET: Klienties
        public async Task<IActionResult> Index()
        {
            var insuranceCompanyContext = _context.Klienty.Include(k => k.KodGruppyNavigation);
            return View(await insuranceCompanyContext.ToListAsync());
        }

        // GET: Klienties/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klienty = await _context.Klienty
                .Include(k => k.KodGruppyNavigation)
                .FirstOrDefaultAsync(m => m.KodKlienta == id);
            if (klienty == null)
            {
                return NotFound();
            }

            return View(klienty);
        }

        // GET: Klienties/Create
        public IActionResult Create()
        {
            ViewData["KodGruppy"] = new SelectList(_context.GruppyKlientov, "KodGruppy", "Naimenovanie");
            return View();
        }

        // POST: Klienties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KodKlienta,Fio,DataRozhdeniya,Pol,Adres,Telefon,PasportnyeDannye,KodGruppy")] Klienty klienty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klienty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KodGruppy"] = new SelectList(_context.GruppyKlientov, "KodGruppy", "Naimenovanie", klienty.KodGruppy);
            return View(klienty);
        }

        // GET: Klienties/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klienty = await _context.Klienty.FindAsync(id);
            if (klienty == null)
            {
                return NotFound();
            }
            ViewData["KodGruppy"] = new SelectList(_context.GruppyKlientov, "KodGruppy", "Naimenovanie", klienty.KodGruppy);
            return View(klienty);
        }

        // POST: Klienties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("KodKlienta,Fio,DataRozhdeniya,Pol,Adres,Telefon,PasportnyeDannye,KodGruppy")] Klienty klienty)
        {
            if (id != klienty.KodKlienta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klienty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientyExists(klienty.KodKlienta))
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
            ViewData["KodGruppy"] = new SelectList(_context.GruppyKlientov, "KodGruppy", "Naimenovanie", klienty.KodGruppy);
            return View(klienty);
        }

        // GET: Klienties/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klienty = await _context.Klienty
                .Include(k => k.KodGruppyNavigation)
                .FirstOrDefaultAsync(m => m.KodKlienta == id);
            if (klienty == null)
            {
                return NotFound();
            }

            return View(klienty);
        }

        // POST: Klienties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var klienty = await _context.Klienty.FindAsync(id);
            _context.Klienty.Remove(klienty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlientyExists(long id)
        {
            return _context.Klienty.Any(e => e.KodKlienta == id);
        }
    }
}
