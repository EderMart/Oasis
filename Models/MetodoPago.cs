using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class MetodoPago
{
    public int CodigoMetodoPago { get; set; }

    public string? NombreMetodoPago { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
