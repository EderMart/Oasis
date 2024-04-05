using Microsoft.AspNetCore.Mvc;

using Oasis.Models;
using Oasis.Recursos;
using Oasis.Servicios.Contrato;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Oasis.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioServicio;
        public InicioController(IUsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }


        [HttpGet]
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario modelo)
        {
            modelo.Contraseña = Utilidades.EncriptarClave(modelo.Contraseña);
            Usuario usuario_creado = await _usuarioServicio.SaveUsuarios(modelo);


            if (usuario_creado.Documento > 0)
                return RedirectToAction("IniciarSesion", "Inicio");

            ViewData["Mnesaje"] = "No se pudo crear el usuario";

            return View();
        }


        [HttpGet]
        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(int documento, string nombre, string apellido, string correo, string contraseña, string celular, string ciudad, string direccion, string estado, string genero, string telefono, int codigoRol, int codigoTipoDoc)
        {

            Usuario usuario_encontrado = await _usuarioServicio.GetUsuarios(correo, Utilidades.EncriptarClave(contraseña));

            if(usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontraron coincidencias";

                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,usuario_encontrado.Nombre)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return RedirectToAction("Index", "Home");
        }
    }

}
