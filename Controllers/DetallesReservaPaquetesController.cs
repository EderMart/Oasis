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
    public class DetallesReservaPaquetesController : Controller
    {
        private readonly OasisContext _context;

        public DetallesReservaPaquetesController(OasisContext context)
        {
            _context = context;
        }

        // GET: DetallesReservaPaquetes
        public async Task<IActionResult> Index()
        {
            var oasisContext = _context.DetallesReservaPaquetes.Include(d => d.CodigoPaqueteNavigation).Include(d => d.CodigoReservaNavigation);
            return View(await oasisContext.ToListAsync());
        }

        // GET: DetallesReservaPaquetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetallesReservaPaquetes == null)
            {
                return NotFound();
            }

            var detallesReservaPaquete = await _context.DetallesReservaPaquetes
                .Include(d => d.CodigoPaqueteNavigation)
                .Include(d => d.CodigoReservaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoDetallesReserva == id);
            if (detallesReservaPaquete == null)
            {
                return NotFound();
            }

            return View(detallesReservaPaquete);
        }

        // GET: DetallesReservaPaquetes/Create
        public IActionResult Create()
        {
            ViewData["CodigoPaquete"] = new SelectList(_context.Paquetes, "CodigoPaquete", "CodigoPaquete");
            ViewData["CodigoReserva"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva");
            return View();
        }

        // POST: DetallesReservaPaquetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoDetallesReserva,CodigoReserva,CodigoPaquete,Cantidad,Precio")] DetallesReservaPaquete detallesReservaPaquete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallesReservaPaquete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoPaquete"] = new SelectList(_context.Paquetes, "CodigoPaquete", "CodigoPaquete", detallesReservaPaquete.CodigoPaquete);
            ViewData["CodigoReserva"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva", detallesReservaPaquete.CodigoReserva);
            return View(detallesReservaPaquete);
        }

        // GET: DetallesReservaPaquetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetallesReservaPaquetes == null)
            {
                return NotFound();
            }

            var detallesReservaPaquete = await _context.DetallesReservaPaquetes.FindAsync(id);
            if (detallesReservaPaquete == null)
            {
                return NotFound();
            }
            ViewData["CodigoPaquete"] = new SelectList(_context.Paquetes, "CodigoPaquete", "CodigoPaquete", detallesReservaPaquete.CodigoPaquete);
            ViewData["CodigoReserva"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva", detallesReservaPaquete.CodigoReserva);
            return View(detallesReservaPaquete);
        }

        // POST: DetallesReservaPaquetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoDetallesReserva,CodigoReserva,CodigoPaquete,Cantidad,Precio")] DetallesReservaPaquete detallesReservaPaquete)
        {
            if (id != detallesReservaPaquete.CodigoDetallesReserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallesReservaPaquete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallesReservaPaqueteExists(detallesReservaPaquete.CodigoDetallesReserva))
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
            ViewData["CodigoPaquete"] = new SelectList(_context.Paquetes, "CodigoPaquete", "CodigoPaquete", detallesReservaPaquete.CodigoPaquete);
            ViewData["CodigoReserva"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva", detallesReservaPaquete.CodigoReserva);
            return View(detallesReservaPaquete);
        }

        // GET: DetallesReservaPaquetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetallesReservaPaquetes == null)
            {
                return NotFound();
            }

            var detallesReservaPaquete = await _context.DetallesReservaPaquetes
                .Include(d => d.CodigoPaqueteNavigation)
                .Include(d => d.CodigoReservaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoDetallesReserva == id);
            if (detallesReservaPaquete == null)
            {
                return NotFound();
            }

            return View(detallesReservaPaquete);
        }

        // POST: DetallesReservaPaquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetallesReservaPaquetes == null)
            {
                return Problem("Entity set 'OasisContext.DetallesReservaPaquetes'  is null.");
            }
            var detallesReservaPaquete = await _context.DetallesReservaPaquetes.FindAsync(id);
            if (detallesReservaPaquete != null)
            {
                _context.DetallesReservaPaquetes.Remove(detallesReservaPaquete);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallesReservaPaqueteExists(int id)
        {
          return (_context.DetallesReservaPaquetes?.Any(e => e.CodigoDetallesReserva == id)).GetValueOrDefault();
        }
    }
}
