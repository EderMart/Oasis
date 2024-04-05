using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class Servicio
{
    public int CodigoServicio { get; set; }

    public string NombreServicio { get; set; } = null!;

    public int CodigoTipoServ { get; set; }

    public double Precio { get; set; }

    public string Descripcion { get; set; } = null!;

    public string EstadoServicio { get; set; } = null!;

    public virtual TipoServicio CodigoTipoServNavigation { get; set; } = null!;

    public virtual ICollection<DetallesReservaServicio> DetallesReservaServicios { get; set; } = new List<DetallesReservaServicio>();

    public virtual ICollection<PaqueteServicio> PaqueteServicios { get; set; } = new List<PaqueteServicio>();
}
