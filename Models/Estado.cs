using Oasis.Models;
using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}