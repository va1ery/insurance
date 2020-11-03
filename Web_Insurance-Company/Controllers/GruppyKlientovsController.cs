using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Insurance_Company.Data;
using Insurance_Company.Models;

namespace Web_Insurance_Company.Controllers
{
    public class GruppyKlientovsController : Controller
    {
        private readonly InsuranceCompanyContext _context;

        public GruppyKlientovsController(InsuranceCompanyContext context)
        {
            _context = context;
        }

        // GET: GruppyKlientovs
        public async Task<IActionResult> Index()
        {
            return View(await _context.GruppyKlientov.ToListAsync());
        }

        // GET: GruppyKlientovs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gruppyKlientov = await _context.GruppyKlientov
                .FirstOrDefaultAsync(m => m.KodGruppy == id);
            if (gruppyKlientov == null)
            {
                return NotFound();
            }

            return View(gruppyKlientov);
        }

        // GET: GruppyKlientovs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GruppyKlientovs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KodGruppy,Naimenovanie,Opisanie")] GruppyKlientov gruppyKlientov)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gruppyKlientov);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gruppyKlientov);
        }

        // GET: GruppyKlientovs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gruppyKlientov = await _context.GruppyKlientov.FindAsync(id);
            if (gruppyKlientov == null)
            {
                return NotFound();
            }
            return View(gruppyKlientov);
        }

        // POST: GruppyKlientovs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("KodGruppy,Naimenovanie,Opisanie")] GruppyKlientov gruppyKlientov)
        {
            if (id != gruppyKlientov.KodGruppy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gruppyKlientov);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GruppyKlientovExists(gruppyKlientov.KodGruppy))
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
            return View(gruppyKlientov);
        }

        // GET: GruppyKlientovs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gruppyKlientov = await _context.GruppyKlientov
                .FirstOrDefaultAsync(m => m.KodGruppy == id);
            if (gruppyKlientov == null)
            {
                return NotFound();
            }

            return View(gruppyKlientov);
        }

        // POST: GruppyKlientovs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var gruppyKlientov = await _context.GruppyKlientov.FindAsync(id);
            _context.GruppyKlientov.Remove(gruppyKlientov);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GruppyKlientovExists(long id)
        {
            return _context.GruppyKlientov.Any(e => e.KodGruppy == id);
        }
    }
}
