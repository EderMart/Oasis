using System;
using System.Collections.Generic;

namespace Oasis.Models;

public partial class Usuario
{
    public int Documento { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public bool? Estado { get; set; }

    public int? CodigoRol { get; set; }

    public int CodigoTipoDoc { get; set; }

    public virtual Role CodigoRolNavigation { get; set; } = null!;

    public virtual TipoDocumento CodigoTipoDocNavigation { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
