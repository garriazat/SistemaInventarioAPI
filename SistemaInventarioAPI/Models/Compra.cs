using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventarioAPI.Models;

[Table("Compra")]
public partial class Compra
{
    [Key]
    [Column("IDCompra")]
    public int Idcompra { get; set; }

    [Column("fecha_compra", TypeName = "date")]
    public DateTime? FechaCompra { get; set; }

    [Column("fecha_entrega", TypeName = "date")]
    public DateTime? FechaEntrega { get; set; }

    [Column("costo_total", TypeName = "money")]
    public decimal? CostoTotal { get; set; }

    [Column("IDProveedor")]
    public int? Idproveedor { get; set; }

    //[InverseProperty("IdcompraNavigation")]
    //public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    //[ForeignKey("Idproveedor")]
    //[InverseProperty("Compras")]
    //public virtual Proveedor? IdproveedorNavigation { get; set; }
}
