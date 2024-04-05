using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class PaqueteServicio
{
    public int CodigoPaqServ { get; set; }

    public int CodigoPaquete { get; set; }

    public int CodigoServicio { get; set; }

    public double Precio { get; set; }

    public virtual Paquete CodigoPaqueteNavigation { get; set; } = null!;

    public virtual Servicio CodigoServicioNavigation { get; set; } = null!;
}
