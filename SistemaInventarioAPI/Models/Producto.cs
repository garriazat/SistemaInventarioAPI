using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventarioAPI.Models;

[Table("Producto")]
public partial class Producto
{
    [Key]
    [Column("IDProducto")]
    public int Idproducto { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("descripcion")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column("costo", TypeName = "money")]
    public decimal? Costo { get; set; }

    [Column("cantidad")]
    public int? Cantidad { get; set; }

    [Column("IDMarca")]
    public int? Idmarca { get; set; }

    [Column("IDCategoria")]
    public int? Idcategoria { get; set; }

    //[InverseProperty("IdproductoNavigation")]
    //public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    //[InverseProperty("IdproductoNavigation")]
    //public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; } = new List<DetalleOrden>();

    //[ForeignKey("Idcategoria")]
    //[InverseProperty("Productos")]
    //public virtual Categoria? IdcategoriaNavigation { get; set; }

    //[ForeignKey("Idmarca")]
    //[InverseProperty("Productos")]
    //public virtual Marca? IdmarcaNavigation { get; set; }
}
