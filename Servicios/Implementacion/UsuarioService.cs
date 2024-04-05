using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Oasis.Models;
using Oasis.Servicios.Contrato;

namespace Oasis.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly OasisContext _dbContext;
        public UsuarioService(OasisContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Usuario> GetUsuarios(string correo, string contraseña)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.Correo == correo && u.Contraseña == contraseña)
                .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuarios(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();

            return modelo;
        }
    }
}
