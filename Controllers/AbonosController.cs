using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oasis.Models;

namespace Oasis.Controllers
{
    public class AbonosController : Controller
    {
        private readonly OasisContext _context;

        public AbonosController(OasisContext context)
        {
            _context = context;
        }

        // GET: Abonoes
        public async Task<IActionResult> Index()
        {
            var oasisContext = _context.Abonos.Include(a => a.CodigoReservaNavigation);
            return View(await oasisContext.ToListAsync());
        }

        // GET: Abonoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Abonos == null)
            {
                return NotFound();
            }

            var abono = await _context.Abonos
                .Include(a => a.CodigoReservaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoAbono == id);
            if (abono == null)
            {
                return NotFound();
            }

            return View(abono);
        }

        // GET: Abonoes/Create
        public IActionResult Create()
        {
            ViewData["CodigoReserva"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva");
            return View();
        }

        // POST: Abonoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoAbono,Documento,CodigoReserva,Fecha,Estado,ValorDeuda,Porcentaje,TotalPendiente,Subtotal,Iva,TotalAbonado")] Abono abono)
        {
            if (ModelState.IsValid)
            {
                _context.Add(abono);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoReserva"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva", abono.CodigoReserva);
            return View(abono);
        }

        // GET: Abonoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Abonos == null)
            {
                return NotFound();
            }

            var abono = await _context.Abonos.FindAsync(id);
            if (abono == null)
            {
                return NotFound();
            }
            ViewData["CodigoReserva"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva", abono.CodigoReserva);
            return View(abono);
        }

        // POST: Abonoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoAbono,Documento,CodigoReserva,Fecha,Estado,ValorDeuda,Porcentaje,TotalPendiente,Subtotal,Iva,TotalAbonado")] Abono abono)
        {
            if (id != abono.CodigoAbono)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(abono);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbonoExists(abono.CodigoAbono))
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
            ViewData["CodigoReserva"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva", abono.CodigoReserva);
            return View(abono);
        }

        // GET: Abonoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Abonos == null)
            {
                return NotFound();
            }

            var abono = await _context.Abonos
                .Include(a => a.CodigoReservaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoAbono == id);
            if (abono == null)
            {
                return NotFound();
            }

            return View(abono);
        }

        // POST: Abonoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Abonos == null)
            {
                return Problem("Entity set 'OasisContext.Abonos'  is null.");
            }
            var abono = await _context.Abonos.FindAsync(id);
            if (abono != null)
            {
                _context.Abonos.Remove(abono);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbonoExists(int id)
        {
          return (_context.Abonos?.Any(e => e.CodigoAbono == id)).GetValueOrDefault();
        }
    }
}
