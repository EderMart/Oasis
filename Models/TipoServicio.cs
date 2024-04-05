using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class TipoServicio
{
    public int CodigoTipoServ { get; set; }

    public string? NombreTipoServ { get; set; }

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
