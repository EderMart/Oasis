using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Oasis.Models;

public partial class OasisContext : DbContext
{
    public OasisContext()
    {
    }

    public OasisContext(DbContextOptions<OasisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abono> Abonos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetallesReservaPaquete> DetallesReservaPaquetes { get; set; }

    public virtual DbSet<DetallesReservaServicio> DetallesReservaServicios { get; set; }

    public virtual DbSet<EstadoReserva> EstadoReservas { get; set; }

    public virtual DbSet<Habitacione> Habitaciones { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<Paquete> Paquetes { get; set; }

    public virtual DbSet<PaqueteServicio> PaqueteServicios { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<PermisosRole> PermisosRoles { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoHabitacione> TipoHabitaciones { get; set; }

    public virtual DbSet<TipoServicio> TipoServicios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=DESKTOP-B8U20BH\SQLEXPRESS;Initial Catalog=Oasis1;integrated security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Abono>(entity =>
        {
            entity.HasKey(e => e.CodigoAbono).HasName("PK__Abonos__7BDEBAEDE2D4C584");

            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Iva).HasColumnName("IVA");

            entity.HasOne(d => d.CodigoReservaNavigation).WithMany(p => p.Abonos)
                .HasForeignKey(d => d.CodigoReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Abonos__CodigoRe__6A30C649");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Documento).HasName("PK__Clientes__AF73706CEF1DE607");

            entity.Property(e => e.Documento).ValueGeneratedNever();
            entity.Property(e => e.Apellido)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Ciudad)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Contraseña)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoRolNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.CodigoRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clientes__Codigo__59063A47");

            entity.HasOne(d => d.CodigoTipoDocNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.CodigoTipoDoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clientes__Codigo__59FA5E80");
        });

        modelBuilder.Entity<DetallesReservaPaquete>(entity =>
        {
            entity.HasKey(e => e.CodigoDetallesReserva).HasName("PK__Detalles__392831E067D56CF5");

            entity.ToTable("DetallesReservaPaquete");

            entity.HasOne(d => d.CodigoPaqueteNavigation).WithMany(p => p.DetallesReservaPaquetes)
                .HasForeignKey(d => d.CodigoPaquete)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallesR__Codig__628FA481");

            entity.HasOne(d => d.CodigoReservaNavigation).WithMany(p => p.DetallesReservaPaquetes)
                .HasForeignKey(d => d.CodigoReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallesR__Codig__6383C8BA");
        });

        modelBuilder.Entity<DetallesReservaServicio>(entity =>
        {
            entity.HasKey(e => e.CodigoDetallesReserva).HasName("PK__Detalles__392831E01E60C2B2");

            entity.ToTable("DetallesReservaServicio");

            entity.HasOne(d => d.CodigoReservaNavigation).WithMany(p => p.DetallesReservaServicios)
                .HasForeignKey(d => d.CodigoReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallesR__Codig__66603565");

            entity.HasOne(d => d.CodigoServicioNavigation).WithMany(p => p.DetallesReservaServicios)
                .HasForeignKey(d => d.CodigoServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallesR__Codig__6754599E");
        });

        modelBuilder.Entity<EstadoReserva>(entity =>
        {
            entity.HasKey(e => e.CodigoEstadoRes).HasName("PK__EstadoRe__BE9F94CDFC059528");

            entity.ToTable("EstadoReserva");

            entity.Property(e => e.NombreEstadoRes)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Habitacione>(entity =>
        {
            entity.HasKey(e => e.CodigoHabitacion).HasName("PK__Habitaci__B90DF36ABE00CCEC");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.EstadoHabitacion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NombreHabitacion)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoTipoHabNavigation).WithMany(p => p.Habitaciones)
                .HasForeignKey(d => d.CodigoTipoHab)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Habitacio__Codig__4CA06362");
        });

        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasKey(e => e.CodigoMetodoPago).HasName("PK__MetodoPa__6F0B3995A3FEF39C");

            entity.Property(e => e.NombreMetodoPago)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Paquete>(entity =>
        {
            entity.HasKey(e => e.CodigoPaquete).HasName("PK__Paquetes__348E4E712B464CFC");

            entity.Property(e => e.NombrePaquete)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoHabitacionNavigation).WithMany(p => p.Paquetes)
                .HasForeignKey(d => d.CodigoHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Paquetes__Codigo__52593CB8");
        });

        modelBuilder.Entity<PaqueteServicio>(entity =>
        {
            entity.HasKey(e => e.CodigoPaqServ).HasName("PK__PaqueteS__580C1F3637B01590");

            entity.ToTable("PaqueteServicio");

            entity.HasOne(d => d.CodigoPaqueteNavigation).WithMany(p => p.PaqueteServicios)
                .HasForeignKey(d => d.CodigoPaquete)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PaqueteSe__Codig__5535A963");

            entity.HasOne(d => d.CodigoServicioNavigation).WithMany(p => p.PaqueteServicios)
                .HasForeignKey(d => d.CodigoServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PaqueteSe__Codig__5629CD9C");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.CodigoPermiso).HasName("PK__Permisos__C41038547FD8A1A4");

            entity.Property(e => e.NombrePermiso)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PermisosRole>(entity =>
        {
            entity.HasKey(e => e.CodigoPermisoRol).HasName("PK__Permisos__407D02F04F788CF1");

            entity.HasOne(d => d.CodigoPermisoNavigation).WithMany(p => p.PermisosRoles)
                .HasForeignKey(d => d.CodigoPermiso)
                .HasConstraintName("FK__PermisosR__Codig__45F365D3");

            entity.HasOne(d => d.CodigoRolNavigation).WithMany(p => p.PermisosRoles)
                .HasForeignKey(d => d.CodigoRol)
                .HasConstraintName("FK__PermisosR__Codig__44FF419A");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.CodigoReserva).HasName("PK__Reservas__F4D3D983BD77F6B7");

            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.FechaFinalizacion).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.Iva).HasColumnName("IVA");

            entity.HasOne(d => d.CodigoEstadoResNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.CodigoEstadoRes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservas__Codigo__5FB337D6");

            entity.HasOne(d => d.CodigoMetodoPagoNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.CodigoMetodoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservas__Codigo__5EBF139D");

            entity.HasOne(d => d.DocumentoClienteNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.DocumentoCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservas__Docume__5CD6CB2B");

            entity.HasOne(d => d.DocumentoUsuarioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.DocumentoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservas__Docume__5DCAEF64");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.CodigoRol).HasName("PK__Roles__F0D130573B36F6A6");

            entity.Property(e => e.EstadoRol)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.NombreRol)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.CodigoServicio).HasName("PK__Servicio__32DEAC55BE7F14C2");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.EstadoServicio)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoTipoServNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.CodigoTipoServ)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Servicios__Estad__4F7CD00D");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.CodigoTipoDoc).HasName("PK__TipoDocu__A4FE981A70C3AC0C");

            entity.Property(e => e.NombreTipoDoc)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoHabitacione>(entity =>
        {
            entity.HasKey(e => e.CodigoTipoHab).HasName("PK__TipoHabi__A5FF33561F987680");

            entity.Property(e => e.EstadoTipoHab)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NombreTipoHab)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoServicio>(entity =>
        {
            entity.HasKey(e => e.CodigoTipoServ).HasName("PK__TipoServ__85FC75F1D37268E7");

            entity.Property(e => e.NombreTipoServ)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Documento).HasName("PK__Usuarios__AF73706CCE423262");

            entity.Property(e => e.Documento).ValueGeneratedNever();
            entity.Property(e => e.Apellido)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Ciudad)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Contraseña)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.CodigoRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__Codigo__48CFD27E");

            entity.HasOne(d => d.CodigoTipoDocNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.CodigoTipoDoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__Codigo__49C3F6B7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
