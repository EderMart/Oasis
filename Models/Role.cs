using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class Role
{
    public int CodigoRol { get; set; }

    public string NombreRol { get; set; } = null!;

    public string EstadoRol { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<PermisosRole> PermisosRoles { get; set; } = new List<PermisosRole>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
