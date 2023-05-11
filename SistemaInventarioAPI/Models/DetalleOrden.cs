using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventarioAPI.Models;

[Table("Detalle_Orden")]
public partial class DetalleOrden
{
    [Key]
    [Column("IDDetalle_Orden")]
    public int IddetalleOrden { get; set; }

    [Column("cantidad")]
    public int? Cantidad { get; set; }

    [Column("IDOrden")]
    public int? Idorden { get; set; }

    [Column("IDProducto")]
    public int? Idproducto { get; set; }

    //[ForeignKey("Idorden")]
    //[InverseProperty("DetalleOrdenes")]
    //public virtual Orden? IdordenNavigation { get; set; }

    //[ForeignKey("Idproducto")]
    //[InverseProperty("DetalleOrdenes")]
    //public virtual Producto? IdproductoNavigation { get; set; }
}
