using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class Abono
{
    public int CodigoAbono { get; set; }

    public int Documento { get; set; }

    public int CodigoReserva { get; set; }

    public DateTime Fecha { get; set; }

    public string Estado { get; set; } = null!;

    public double ValorDeuda { get; set; }

    public double Porcentaje { get; set; }

    public double TotalPendiente { get; set; }

    public double Subtotal { get; set; }

    public double Iva { get; set; }

    public double TotalAbonado { get; set; }

    public virtual Reserva CodigoReservaNavigation { get; set; } = null!;
}
