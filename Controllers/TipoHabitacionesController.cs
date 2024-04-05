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
    public class TipoHabitacionesController : Controller
    {
        private readonly OasisContext _context;

        public TipoHabitacionesController(OasisContext context)
        {
            _context = context;
        }

        // GET: TipoHabitaciones
        public async Task<IActionResult> Index()
        {
              return _context.TipoHabitaciones != null ? 
                          View(await _context.TipoHabitaciones.ToListAsync()) :
                          Problem("Entity set 'OasisContext.TipoHabitaciones'  is null.");
        }

        // GET: TipoHabitaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoHabitaciones == null)
            {
                return NotFound();
            }

            var tipoHabitacione = await _context.TipoHabitaciones
                .FirstOrDefaultAsync(m => m.CodigoTipoHab == id);
            if (tipoHabitacione == null)
            {
                return NotFound();
            }

            return View(tipoHabitacione);
        }

        // GET: TipoHabitaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoHabitaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoTipoHab,NombreTipoHab,EstadoTipoHab,NumPersonas")] TipoHabitacione tipoHabitacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoHabitacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoHabitacione);
        }

        // GET: TipoHabitaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoHabitaciones == null)
            {
                return NotFound();
            }

            var tipoHabitacione = await _context.TipoHabitaciones.FindAsync(id);
            if (tipoHabitacione == null)
            {
                return NotFound();
            }
            return View(tipoHabitacione);
        }

        // POST: TipoHabitaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoTipoHab,NombreTipoHab,EstadoTipoHab,NumPersonas")] TipoHabitacione tipoHabitacione)
        {
            if (id != tipoHabitacione.CodigoTipoHab)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoHabitacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoHabitacioneExists(tipoHabitacione.CodigoTipoHab))
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
            return View(tipoHabitacione);
        }

        // GET: TipoHabitaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoHabitaciones == null)
            {
                return NotFound();
            }

            var tipoHabitacione = await _context.TipoHabitaciones
                .FirstOrDefaultAsync(m => m.CodigoTipoHab == id);
            if (tipoHabitacione == null)
            {
                return NotFound();
            }

            return View(tipoHabitacione);
        }

        // POST: TipoHabitaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoHabitaciones == null)
            {
                return Problem("Entity set 'OasisContext.TipoHabitaciones'  is null.");
            }
            var tipoHabitacione = await _context.TipoHabitaciones.FindAsync(id);
            if (tipoHabitacione != null)
            {
                _context.TipoHabitaciones.Remove(tipoHabitacione);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoHabitacioneExists(int id)
        {
          return (_context.TipoHabitaciones?.Any(e => e.CodigoTipoHab == id)).GetValueOrDefault();
        }
    }
}
