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
    public class PermisosController : Controller
    {
        private readonly OasisContext _context;

        public PermisosController(OasisContext context)
        {
            _context = context;
        }

        // GET: Permisoes
        public async Task<IActionResult> Index()
        {
              return _context.Permisos != null ? 
                          View(await _context.Permisos.ToListAsync()) :
                          Problem("Entity set 'OasisContext.Permisos'  is null.");
        }

        // GET: Permisoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Permisos == null)
            {
                return NotFound();
            }

            var permiso = await _context.Permisos
                .FirstOrDefaultAsync(m => m.CodigoPermiso == id);
            if (permiso == null)
            {
                return NotFound();
            }

            return View(permiso);
        }

        // GET: Permisoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Permisoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoPermiso,NombrePermiso")] Permiso permiso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permiso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(permiso);
        }

        // GET: Permisoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Permisos == null)
            {
                return NotFound();
            }

            var permiso = await _context.Permisos.FindAsync(id);
            if (permiso == null)
            {
                return NotFound();
            }
            return View(permiso);
        }

        // POST: Permisoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoPermiso,NombrePermiso")] Permiso permiso)
        {
            if (id != permiso.CodigoPermiso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permiso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermisoExists(permiso.CodigoPermiso))
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
            return View(permiso);
        }

        // GET: Permisoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Permisos == null)
            {
                return NotFound();
            }

            var permiso = await _context.Permisos
                .FirstOrDefaultAsync(m => m.CodigoPermiso == id);
            if (permiso == null)
            {
                return NotFound();
            }

            return View(permiso);
        }

        // POST: Permisoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Permisos == null)
            {
                return Problem("Entity set 'OasisContext.Permisos'  is null.");
            }
            var permiso = await _context.Permisos.FindAsync(id);
            if (permiso != null)
            {
                _context.Permisos.Remove(permiso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermisoExists(int id)
        {
          return (_context.Permisos?.Any(e => e.CodigoPermiso == id)).GetValueOrDefault();
        }
    }
}
