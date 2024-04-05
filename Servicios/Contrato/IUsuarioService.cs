using Microsoft.EntityFrameworkCore;
using Oasis.Models;
using Oasis.Servicios.Implementacion;

namespace Oasis.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuarios(string correo, string contraseña);

        Task<Usuario> SaveUsuarios(Usuario modelo);
    }
}
