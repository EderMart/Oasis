using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class EstadoReserva
{
    public int CodigoEstadoRes { get; set; }

    public string NombreEstadoRes { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
