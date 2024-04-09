using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class Usuario
{
    public int Documento { get; set; }

    public string? Nombre { get; set; } 

    public string? Apellido { get; set; }

    public string? Celular { get; set; } 

    public string? Correo { get; set; } 

    public string? Ciudad { get; set; } 

    public DateTime? FechaNacimiento { get; set; }

    public string? Genero { get; set; } 

    public string? Contraseña { get; set; }

    public string? Telefono { get; set; } 

    public string? Direccion { get; set; }

    public bool? Estado { get; set; }

    public int? CodigoRol { get; set; }

    public int? CodigoTipoDoc { get; set; }

    public virtual Role CodigoRolNavigation { get; set; } = null!;

    public virtual TipoDocumento CodigoTipoDocNavigation { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
