﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oasis.Models;

namespace Oasis.Controllers
{
    public class MetodoPagosController : Controller
    {
        private readonly OasisContext _context;

        public MetodoPagosController(OasisContext context)
        {
            _context = context;
        }

        // GET: MetodoPagoes
        public async Task<IActionResult> Index()
        {
              return _context.MetodoPagos != null ? 
                          View(await _context.MetodoPagos.ToListAsync()) :
                          Problem("Entity set 'OasisContext.MetodoPagos'  is null.");
        }

        // GET: MetodoPagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MetodoPagos == null)
            {
                return NotFound();
            }

            var metodoPago = await _context.MetodoPagos
                .FirstOrDefaultAsync(m => m.CodigoMetodoPago == id);
            if (metodoPago == null)
            {
                return NotFound();
            }

            return View(metodoPago);
        }

        // GET: MetodoPagoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MetodoPagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoMetodoPago,NombreMetodoPago")] MetodoPago metodoPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metodoPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(metodoPago);
        }

        // GET: MetodoPagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MetodoPagos == null)
            {
                return NotFound();
            }

            var metodoPago = await _context.MetodoPagos.FindAsync(id);
            if (metodoPago == null)
            {
                return NotFound();
            }
            return View(metodoPago);
        }

        // POST: MetodoPagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoMetodoPago,NombreMetodoPago")] MetodoPago metodoPago)
        {
            if (id != metodoPago.CodigoMetodoPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metodoPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetodoPagoExists(metodoPago.CodigoMetodoPago))
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
            return View(metodoPago);
        }

        // GET: MetodoPagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MetodoPagos == null)
            {
                return NotFound();
            }

            var metodoPago = await _context.MetodoPagos
                .FirstOrDefaultAsync(m => m.CodigoMetodoPago == id);
            if (metodoPago == null)
            {
                return NotFound();
            }

            return View(metodoPago);
        }

        // POST: MetodoPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MetodoPagos == null)
            {
                return Problem("Entity set 'OasisContext.MetodoPagos'  is null.");
            }
            var metodoPago = await _context.MetodoPagos.FindAsync(id);
            if (metodoPago != null)
            {
                _context.MetodoPagos.Remove(metodoPago);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetodoPagoExists(int id)
        {
          return (_context.MetodoPagos?.Any(e => e.CodigoMetodoPago == id)).GetValueOrDefault();
        }
    }
}
