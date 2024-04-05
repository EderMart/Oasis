using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class DetallesReservaServicio
{
    public int CodigoDetallesReserva { get; set; }

    public int CodigoReserva { get; set; }

    public int CodigoServicio { get; set; }

    public double Precio { get; set; }

    public virtual Reserva CodigoReservaNavigation { get; set; } = null!;

    public virtual Servicio CodigoServicioNavigation { get; set; } = null!;
}
