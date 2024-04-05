using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class Habitacione
{
    public int CodigoHabitacion { get; set; }

    public string NombreHabitacion { get; set; } = null!;

    public int CodigoTipoHab { get; set; }

    public string EstadoHabitacion { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public double Precio { get; set; }

    public virtual TipoHabitacione CodigoTipoHabNavigation { get; set; } = null!;

    public virtual ICollection<Paquete> Paquetes { get; set; } = new List<Paquete>();
}
