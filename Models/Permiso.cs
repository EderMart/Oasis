using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class Permiso
{
    public int CodigoPermiso { get; set; }

    public string NombrePermiso { get; set; } = null!;

    public virtual ICollection<PermisosRole> PermisosRoles { get; set; } = new List<PermisosRole>();
}
