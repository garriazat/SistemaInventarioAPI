using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventarioAPI.Models;

[Table("Detalle_Compra")]
public partial class DetalleCompra
{
    [Key]
    [Column("IDDetalle_Compra")]
    public int IddetalleCompra { get; set; }

    [Column("cantidad")]
    public int? Cantidad { get; set; }

    [Column("costo_unidad", TypeName = "money")]
    public decimal? CostoUnidad { get; set; }

    [Column("IDCompra")]
    public int? Idcompra { get; set; }

    [Column("IDProducto")]
    public int? Idproducto { get; set; }

    [ForeignKey("Idcompra")]
    [InverseProperty("DetalleCompras")]
    public virtual Compra? IdcompraNavigation { get; set; }

    [ForeignKey("Idproducto")]
    [InverseProperty("DetalleCompras")]
    public virtual Producto? IdproductoNavigation { get; set; }
}
