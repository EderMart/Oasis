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
    public class PaqueteServiciosController : Controller
    {
        private readonly OasisContext _context;

        public PaqueteServiciosController(OasisContext context)
        {
            _context = context;
        }

        // GET: PaqueteServicios
        public async Task<IActionResult> Index()
        {
            var oasisContext = _context.PaqueteServicios.Include(p => p.CodigoPaqueteNavigation).Include(p => p.CodigoServicioNavigation);
            return View(await oasisContext.ToListAsync());
        }

        // GET: PaqueteServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PaqueteServicios == null)
            {
                return NotFound();
            }

            var paqueteServicio = await _context.PaqueteServicios
                .Include(p => p.CodigoPaqueteNavigation)
                .Include(p => p.CodigoServicioNavigation)
                .FirstOrDefaultAsync(m => m.CodigoPaqServ == id);
            if (paqueteServicio == null)
            {
                return NotFound();
            }

            return View(paqueteServicio);
        }

        // GET: PaqueteServicios/Create
        public IActionResult Create()
        {
            ViewData["CodigoPaquete"] = new SelectList(_context.Paquetes, "CodigoPaquete", "CodigoPaquete");
            ViewData["CodigoServicio"] = new SelectList(_context.Servicios, "CodigoServicio", "CodigoServicio");
            return View();
        }

        // POST: PaqueteServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoPaqServ,CodigoPaquete,CodigoServicio,Precio")] PaqueteServicio paqueteServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paqueteServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoPaquete"] = new SelectList(_context.Paquetes, "CodigoPaquete", "CodigoPaquete", paqueteServicio.CodigoPaquete);
            ViewData["CodigoServicio"] = new SelectList(_context.Servicios, "CodigoServicio", "CodigoServicio", paqueteServicio.CodigoServicio);
            return View(paqueteServicio);
        }

        // GET: PaqueteServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PaqueteServicios == null)
            {
                return NotFound();
            }

            var paqueteServicio = await _context.PaqueteServicios.FindAsync(id);
            if (paqueteServicio == null)
            {
                return NotFound();
            }
            ViewData["CodigoPaquete"] = new SelectList(_context.Paquetes, "CodigoPaquete", "CodigoPaquete", paqueteServicio.CodigoPaquete);
            ViewData["CodigoServicio"] = new SelectList(_context.Servicios, "CodigoServicio", "CodigoServicio", paqueteServicio.CodigoServicio);
            return View(paqueteServicio);
        }

        // POST: PaqueteServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoPaqServ,CodigoPaquete,CodigoServicio,Precio")] PaqueteServicio paqueteServicio)
        {
            if (id != paqueteServicio.CodigoPaqServ)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paqueteServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaqueteServicioExists(paqueteServicio.CodigoPaqServ))
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
            ViewData["CodigoPaquete"] = new SelectList(_context.Paquetes, "CodigoPaquete", "CodigoPaquete", paqueteServicio.CodigoPaquete);
            ViewData["CodigoServicio"] = new SelectList(_context.Servicios, "CodigoServicio", "CodigoServicio", paqueteServicio.CodigoServicio);
            return View(paqueteServicio);
        }

        // GET: PaqueteServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PaqueteServicios == null)
            {
                return NotFound();
            }

            var paqueteServicio = await _context.PaqueteServicios
                .Include(p => p.CodigoPaqueteNavigation)
                .Include(p => p.CodigoServicioNavigation)
                .FirstOrDefaultAsync(m => m.CodigoPaqServ == id);
            if (paqueteServicio == null)
            {
                return NotFound();
            }

            return View(paqueteServicio);
        }

        // POST: PaqueteServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PaqueteServicios == null)
            {
                return Problem("Entity set 'OasisContext.PaqueteServicios'  is null.");
            }
            var paqueteServicio = await _context.PaqueteServicios.FindAsync(id);
            if (paqueteServicio != null)
            {
                _context.PaqueteServicios.Remove(paqueteServicio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaqueteServicioExists(int id)
        {
          return (_context.PaqueteServicios?.Any(e => e.CodigoPaqServ == id)).GetValueOrDefault();
        }
    }
}
