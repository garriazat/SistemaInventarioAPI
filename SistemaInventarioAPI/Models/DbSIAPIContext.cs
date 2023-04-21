using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventarioAPI.Models;

public partial class DbSIAPIContext : DbContext
{
    public DbSIAPIContext()
    {
    }

    public DbSIAPIContext(DbContextOptions<DbSIAPIContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleOrden> DetalleOrdens { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Orden> Ordens { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("name=DefaultConnection");

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Idcategoria).HasName("PK__Categori__70E82E285559D4FB");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.Idcompra).HasName("PK__Compra__08719EC1ABD670A8");

            entity.HasOne(d => d.IdproveedorNavigation).WithMany(p => p.Compras).HasConstraintName("FK__Compra__IDProvee__36B12243");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.IddetalleCompra).HasName("PK__Detalle___E67D6CAF30C1775D");

            entity.HasOne(d => d.IdcompraNavigation).WithMany(p => p.DetalleCompras).HasConstraintName("FK__Detalle_C__IDCom__398D8EEE");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.DetalleCompras).HasConstraintName("FK__Detalle_C__IDPro__3A81B327");
        });

        modelBuilder.Entity<DetalleOrden>(entity =>
        {
            entity.HasKey(e => e.IddetalleOrden).HasName("PK__Detalle___60397FE415970921");

            entity.HasOne(d => d.IdordenNavigation).WithMany(p => p.DetalleOrdens).HasConstraintName("FK__Detalle_O__IDOrd__32E0915F");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.DetalleOrdens).HasConstraintName("FK__Detalle_O__IDPro__33D4B598");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Idmarca).HasName("PK__Marca__CEC375E7BD49DC7A");
        });

        modelBuilder.Entity<Orden>(entity =>
        {
            entity.HasKey(e => e.Idorden).HasName("PK__Orden__5CBBCAD79FA9B953");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Ordens).HasConstraintName("FK__Orden__IDUsuario__300424B4");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PK__Producto__ABDAF2B49685CFC3");

            entity.HasOne(d => d.IdcategoriaNavigation).WithMany(p => p.Productos).HasConstraintName("FK__Producto__IDCate__2D27B809");

            entity.HasOne(d => d.IdmarcaNavigation).WithMany(p => p.Productos).HasConstraintName("FK__Producto__IDMarc__2C3393D0");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Idproveedor).HasName("PK__Proveedo__4CD73240BAC0F826");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__Usuario__52311169A00A83E4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);*/
}
