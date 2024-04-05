using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class Paquete
{
    public int CodigoPaquete { get; set; }

    public string NombrePaquete { get; set; } = null!;

    public double Valor { get; set; }

    public int CodigoHabitacion { get; set; }

    public virtual Habitacione CodigoHabitacionNavigation { get; set; } = null!;

    public virtual ICollection<DetallesReservaPaquete> DetallesReservaPaquetes { get; set; } = new List<DetallesReservaPaquete>();

    public virtual ICollection<PaqueteServicio> PaqueteServicios { get; set; } = new List<PaqueteServicio>();
}
