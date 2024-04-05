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
    public class DetallesReservaServiciosController : Controller
    {
        private readonly OasisContext _context;

        public DetallesReservaServiciosController(OasisContext context)
        {
            _context = context;
        }

        // GET: DetallesReservaServicios
        public async Task<IActionResult> Index()
        {
            var oasisContext = _context.DetallesReservaServicios.Include(d => d.CodigoReservaNavigation).Include(d => d.CodigoServicioNavigation);
            return View(await oasisContext.ToListAsync());
        }

        // GET: DetallesReservaServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetallesReservaServicios == null)
            {
                return NotFound();
            }

            var detallesReservaServicio = await _context.DetallesReservaServicios
                .Include(d => d.CodigoReservaNavigation)
                .Include(d => d.CodigoServicioNavigation)
                .FirstOrDefaultAsync(m => m.CodigoDetallesReserva == id);
            if (detallesReservaServicio == null)
            {
                return NotFound();
            }

            return View(detallesReservaServicio);
        }

        // GET: DetallesReservaServicios/Create
        public IActionResult Create()
        {
            ViewData["CodigoReserva"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva");
            ViewData["CodigoServicio"] = new SelectList(_context.Servicios, "CodigoServicio", "CodigoServicio");
            return View();
        }

        // POST: DetallesReservaServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoDetallesReserva,CodigoReserva,CodigoServicio,Cantidad,Precio")] DetallesReservaServicio detallesReservaServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallesReservaServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoReserva"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva", detallesReservaServicio.CodigoReserva);
            ViewData["CodigoServicio"] = new SelectList(_context.Servicios, "CodigoServicio", "CodigoServicio", detallesReservaServicio.CodigoServicio);
            return View(detallesReservaServicio);
        }

        // GET: DetallesReservaServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetallesReservaServicios == null)
            {
                return NotFound();
            }

            var detallesReservaServicio = await _context.DetallesReservaServicios.FindAsync(id);
            if (detallesReservaServicio == null)
            {
                return NotFound();
            }
            ViewData["CodigoReserva"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva", detallesReservaServicio.CodigoReserva);
            ViewData["CodigoServicio"] = new SelectList(_context.Servicios, "CodigoServicio", "CodigoServicio", detallesReservaServicio.CodigoServicio);
            return View(detallesReservaServicio);
        }

        // POST: DetallesReservaServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoDetallesReserva,CodigoReserva,CodigoServicio,Cantidad,Precio")] DetallesReservaServicio detallesReservaServicio)
        {
            if (id != detallesReservaServicio.CodigoDetallesReserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallesReservaServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallesReservaServicioExists(detallesReservaServicio.CodigoDetallesReserva))
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
            ViewData["CodigoReserva"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva", detallesReservaServicio.CodigoReserva);
            ViewData["CodigoServicio"] = new SelectList(_context.Servicios, "CodigoServicio", "CodigoServicio", detallesReservaServicio.CodigoServicio);
            return View(detallesReservaServicio);
        }

        // GET: DetallesReservaServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetallesReservaServicios == null)
            {
                return NotFound();
            }

            var detallesReservaServicio = await _context.DetallesReservaServicios
                .Include(d => d.CodigoReservaNavigation)
                .Include(d => d.CodigoServicioNavigation)
                .FirstOrDefaultAsync(m => m.CodigoDetallesReserva == id);
            if (detallesReservaServicio == null)
            {
                return NotFound();
            }

            return View(detallesReservaServicio);
        }

        // POST: DetallesReservaServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetallesReservaServicios == null)
            {
                return Problem("Entity set 'OasisContext.DetallesReservaServicios'  is null.");
            }
            var detallesReservaServicio = await _context.DetallesReservaServicios.FindAsync(id);
            if (detallesReservaServicio != null)
            {
                _context.DetallesReservaServicios.Remove(detallesReservaServicio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallesReservaServicioExists(int id)
        {
          return (_context.DetallesReservaServicios?.Any(e => e.CodigoDetallesReserva == id)).GetValueOrDefault();
        }
    }
}
