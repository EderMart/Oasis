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
    public class ClientesController : Controller
    {
        private readonly OasisContext _context;

        public ClientesController(OasisContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var oasisContext = _context.Clientes.Include(c => c.CodigoRolNavigation).Include(c => c.CodigoTipoDocNavigation);
            return View(await oasisContext.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.CodigoRolNavigation)
                .Include(c => c.CodigoTipoDocNavigation)
                .FirstOrDefaultAsync(m => m.Documento == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewData["CodigoRol"] = new SelectList(_context.Roles, "CodigoRol", "CodigoRol");
            ViewData["CodigoTipoDoc"] = new SelectList(_context.TipoDocumentos, "CodigoTipoDoc", "CodigoTipoDoc");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Documento,Nombre,Apellido,Celular,Correo,Ciudad,Genero,Contraseña,Telefono,Direccion,Estado,CodigoRol,CodigoTipoDoc")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoRol"] = new SelectList(_context.Roles, "CodigoRol", "CodigoRol", cliente.CodigoRol);
            ViewData["CodigoTipoDoc"] = new SelectList(_context.TipoDocumentos, "CodigoTipoDoc", "CodigoTipoDoc", cliente.CodigoTipoDoc);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["CodigoRol"] = new SelectList(_context.Roles, "CodigoRol", "CodigoRol", cliente.CodigoRol);
            ViewData["CodigoTipoDoc"] = new SelectList(_context.TipoDocumentos, "CodigoTipoDoc", "CodigoTipoDoc", cliente.CodigoTipoDoc);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Documento,Nombre,Apellido,Celular,Correo,Ciudad,Genero,Contraseña,Telefono,Direccion,Estado,CodigoRol,CodigoTipoDoc")] Cliente cliente)
        {
            if (id != cliente.Documento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Documento))
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
            ViewData["CodigoRol"] = new SelectList(_context.Roles, "CodigoRol", "CodigoRol", cliente.CodigoRol);
            ViewData["CodigoTipoDoc"] = new SelectList(_context.TipoDocumentos, "CodigoTipoDoc", "CodigoTipoDoc", cliente.CodigoTipoDoc);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.CodigoRolNavigation)
                .Include(c => c.CodigoTipoDocNavigation)
                .FirstOrDefaultAsync(m => m.Documento == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'OasisContext.Clientes'  is null.");
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
          return (_context.Clientes?.Any(e => e.Documento == id)).GetValueOrDefault();
        }
    }
}
