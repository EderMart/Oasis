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
    public class PermisosRolesController : Controller
    {
        private readonly OasisContext _context;

        public PermisosRolesController(OasisContext context)
        {
            _context = context;
        }

        // GET: PermisosRoles
        public async Task<IActionResult> Index()
        {
            var oasisContext = _context.PermisosRoles.Include(p => p.CodigoPermisoNavigation).Include(p => p.CodigoRolNavigation);
            return View(await oasisContext.ToListAsync());
        }

        // GET: PermisosRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PermisosRoles == null)
            {
                return NotFound();
            }

            var permisosRole = await _context.PermisosRoles
                .Include(p => p.CodigoPermisoNavigation)
                .Include(p => p.CodigoRolNavigation)
                .FirstOrDefaultAsync(m => m.CodigoPermisoRol == id);
            if (permisosRole == null)
            {
                return NotFound();
            }

            return View(permisosRole);
        }

        // GET: PermisosRoles/Create
        public IActionResult Create()
        {
            ViewData["CodigoPermiso"] = new SelectList(_context.Permisos, "CodigoPermiso", "CodigoPermiso");
            ViewData["CodigoRol"] = new SelectList(_context.Roles, "CodigoRol", "CodigoRol");
            return View();
        }

        // POST: PermisosRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoPermisoRol,CodigoRol,CodigoPermiso")] PermisosRole permisosRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permisosRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoPermiso"] = new SelectList(_context.Permisos, "CodigoPermiso", "CodigoPermiso", permisosRole.CodigoPermiso);
            ViewData["CodigoRol"] = new SelectList(_context.Roles, "CodigoRol", "CodigoRol", permisosRole.CodigoRol);
            return View(permisosRole);
        }

        // GET: PermisosRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PermisosRoles == null)
            {
                return NotFound();
            }

            var permisosRole = await _context.PermisosRoles.FindAsync(id);
            if (permisosRole == null)
            {
                return NotFound();
            }
            ViewData["CodigoPermiso"] = new SelectList(_context.Permisos, "CodigoPermiso", "CodigoPermiso", permisosRole.CodigoPermiso);
            ViewData["CodigoRol"] = new SelectList(_context.Roles, "CodigoRol", "CodigoRol", permisosRole.CodigoRol);
            return View(permisosRole);
        }

        // POST: PermisosRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoPermisoRol,CodigoRol,CodigoPermiso")] PermisosRole permisosRole)
        {
            if (id != permisosRole.CodigoPermisoRol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permisosRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermisosRoleExists(permisosRole.CodigoPermisoRol))
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
            ViewData["CodigoPermiso"] = new SelectList(_context.Permisos, "CodigoPermiso", "CodigoPermiso", permisosRole.CodigoPermiso);
            ViewData["CodigoRol"] = new SelectList(_context.Roles, "CodigoRol", "CodigoRol", permisosRole.CodigoRol);
            return View(permisosRole);
        }

        // GET: PermisosRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PermisosRoles == null)
            {
                return NotFound();
            }

            var permisosRole = await _context.PermisosRoles
                .Include(p => p.CodigoPermisoNavigation)
                .Include(p => p.CodigoRolNavigation)
                .FirstOrDefaultAsync(m => m.CodigoPermisoRol == id);
            if (permisosRole == null)
            {
                return NotFound();
            }

            return View(permisosRole);
        }

        // POST: PermisosRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PermisosRoles == null)
            {
                return Problem("Entity set 'OasisContext.PermisosRoles'  is null.");
            }
            var permisosRole = await _context.PermisosRoles.FindAsync(id);
            if (permisosRole != null)
            {
                _context.PermisosRoles.Remove(permisosRole);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermisosRoleExists(int id)
        {
          return (_context.PermisosRoles?.Any(e => e.CodigoPermisoRol == id)).GetValueOrDefault();
        }
    }
}
