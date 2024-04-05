using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class TipoDocumento
{
    public int CodigoTipoDoc { get; set; }

    public string? NombreTipoDoc { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
