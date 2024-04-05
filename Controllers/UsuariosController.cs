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
    public class UsuariosController : Controller
    {
        private readonly OasisContext _context;

        public UsuariosController(OasisContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        //public async Task<IActionResult> Index()
        //{
        //    var oasisContext = _context.Usuarios.Include(u => u.CodigoRolNavigation).Include(u => u.CodigoTipoDocNavigation);
        //    return View(await oasisContext.ToListAsync());
        //}

        //Get: Buscador
        //public async Task<IActionResult> Index(string buscar)
        //{
        //    var usuarios = from usuario in _context.Usuarios select usuario;

        //    if (!String.IsNullOrEmpty(buscar))
        //        usuarios = usuarios.Where(s => s.Nombre!.Contains(buscar));

        //    return View(await usuarios.ToListAsync());
        //}

         // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = _context.Usuarios.Include(u => u.CodigoRolNavigation).Include(u => u.CodigoRolNavigation);
            return View(await usuarios.ToListAsync());
        }

        [HttpPost]
        public IActionResult ActualizarEstado(int? id, bool estado)
        {

            if (id.HasValue)
            {
                var rol = _context.Usuarios.Find(id.Value);

                if (rol != null)
                {
                    // Asignar el estado del abono según el valor del parámetro "estado"
                    rol.Estado = estado;
                    _context.SaveChangesAsync();
                    return View(rol);
                }
            }

            return NotFound(); // Abono no encontrado o ID nulo
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.CodigoRolNavigation)
                .Include(u => u.CodigoTipoDocNavigation)
                .FirstOrDefaultAsync(m => m.Documento == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["CodigoRol"] = new SelectList(_context.Roles, "CodigoRol", "CodigoRol");
            ViewData["CodigoTipoDoc"] = new SelectList(_context.TipoDocumentos, "CodigoTipoDoc", "CodigoTipoDoc");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Documento,Nombre,Apellido,Celular,Correo,Ciudad,Genero,Contraseña,Telefono,Direccion,Estado,CodigoRol,CodigoTipoDoc")] Usuario usuario)
        {
            //if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoRol"] = new SelectList(_context.Roles, "CodigoRol", "CodigoRol", usuario.CodigoRol);
            ViewData["CodigoTipoDoc"] = new SelectList(_context.TipoDocumentos, "CodigoTipoDoc", "CodigoTipoDoc", usuario.CodigoTipoDoc);
            return RedirectToAction();
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["CodigoRol"] = new SelectList(_context.Roles, "CodigoRol", "CodigoRol", usuario.CodigoRol);
            ViewData["CodigoTipoDoc"] = new SelectList(_context.TipoDocumentos, "CodigoTipoDoc", "CodigoTipoDoc", usuario.CodigoTipoDoc);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Documento,Nombre,Apellido,Celular,Correo,Ciudad,Genero,Contraseña,Telefono,Direccion,Estado,CodigoRol,CodigoTipoDoc")] Usuario usuario)
        {
            if (id != usuario.Documento)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Documento))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            ViewData["CodigoRol"] = new SelectList(_context.Roles, "CodigoRol", "CodigoRol", usuario.CodigoRol);
            ViewData["CodigoTipoDoc"] = new SelectList(_context.TipoDocumentos, "CodigoTipoDoc", "CodigoTipoDoc", usuario.CodigoTipoDoc);
            return RedirectToAction(nameof(Index));
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.CodigoRolNavigation)
                .Include(u => u.CodigoTipoDocNavigation)
                .FirstOrDefaultAsync(m => m.Documento == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return RedirectToAction();
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'OasisContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuarios?.Any(e => e.Documento == id)).GetValueOrDefault();
        }
    }
}
