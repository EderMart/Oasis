using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class Reserva
{
    public int CodigoReserva { get; set; }

    public int DocumentoCliente { get; set; }

    public int DocumentoUsuario { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFinalizacion { get; set; }

    public int NumPersonas { get; set; }

    public double Descuento { get; set; }

    public double Subtotal { get; set; }

    public double Iva { get; set; }

    public double Total { get; set; }

    public DateTime Fecha { get; set; }

    public int CodigoEstadoRes { get; set; }

    public int CodigoMetodoPago { get; set; }

    public virtual ICollection<Abono> Abonos { get; set; } = new List<Abono>();

    public virtual EstadoReserva CodigoEstadoResNavigation { get; set; } = null!;

    public virtual MetodoPago CodigoMetodoPagoNavigation { get; set; } = null!;

    public virtual ICollection<DetallesReservaPaquete> DetallesReservaPaquetes { get; set; } = new List<DetallesReservaPaquete>();

    public virtual ICollection<DetallesReservaServicio> DetallesReservaServicios { get; set; } = new List<DetallesReservaServicio>();

    public virtual Cliente DocumentoClienteNavigation { get; set; } = null!;

    public virtual Usuario DocumentoUsuarioNavigation { get; set; } = null!;
}
