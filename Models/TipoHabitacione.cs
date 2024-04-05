using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class TipoHabitacione
{
    public int CodigoTipoHab { get; set; }

    public string NombreTipoHab { get; set; } = null!;

    public string EstadoTipoHab { get; set; } = null!;

    public int NumPersonas { get; set; }

    public virtual ICollection<Habitacione> Habitaciones { get; set; } = new List<Habitacione>();
}
