using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Insurance_Company.Data;
using Insurance_Company.Models;

namespace Web_Insurance_Company.Controllers
{
    public class DolzhnostisController : Controller
    {
        private readonly InsuranceCompanyContext _context;

        public DolzhnostisController(InsuranceCompanyContext context)
        {
            _context = context;
        }

        // GET: Dolzhnostis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dolzhnosti.ToListAsync());
        }

        // GET: Dolzhnostis/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dolzhnosti = await _context.Dolzhnosti
                .FirstOrDefaultAsync(m => m.KodDolzhnosti == id);
            if (dolzhnosti == null)
            {
                return NotFound();
            }

            return View(dolzhnosti);
        }

        // GET: Dolzhnostis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dolzhnostis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KodDolzhnosti,NaimenovanieDolzhnosti,Oklad,Obyazannosti,Trebovaniya")] Dolzhnosti dolzhnosti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dolzhnosti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dolzhnosti);
        }

        // GET: Dolzhnostis/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dolzhnosti = await _context.Dolzhnosti.FindAsync(id);
            if (dolzhnosti == null)
            {
                return NotFound();
            }
            return View(dolzhnosti);
        }

        // POST: Dolzhnostis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("KodDolzhnosti,NaimenovanieDolzhnosti,Oklad,Obyazannosti,Trebovaniya")] Dolzhnosti dolzhnosti)
        {
            if (id != dolzhnosti.KodDolzhnosti)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dolzhnosti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DolzhnostiExists(dolzhnosti.KodDolzhnosti))
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
            return View(dolzhnosti);
        }

        // GET: Dolzhnostis/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dolzhnosti = await _context.Dolzhnosti
                .FirstOrDefaultAsync(m => m.KodDolzhnosti == id);
            if (dolzhnosti == null)
            {
                return NotFound();
            }

            return View(dolzhnosti);
        }

        // POST: Dolzhnostis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dolzhnosti = await _context.Dolzhnosti.FindAsync(id);
            _context.Dolzhnosti.Remove(dolzhnosti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DolzhnostiExists(long id)
        {
            return _context.Dolzhnosti.Any(e => e.KodDolzhnosti == id);
        }
    }
}
