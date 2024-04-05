using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class DetallesReservaPaquete
{
    public int CodigoDetallesReserva { get; set; }

    public int CodigoReserva { get; set; }

    public int CodigoPaquete { get; set; }

    public double Precio { get; set; }

    public virtual Paquete CodigoPaqueteNavigation { get; set; } = null!;

    public virtual Reserva CodigoReservaNavigation { get; set; } = null!;
}
