using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class PermisosRole
{
    public int CodigoPermisoRol { get; set; }

    public int? CodigoRol { get; set; }

    public int? CodigoPermiso { get; set; }

    public virtual Permiso? CodigoPermisoNavigation { get; set; }

    public virtual Role? CodigoRolNavigation { get; set; }
}
