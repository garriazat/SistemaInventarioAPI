using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventarioAPI.Models;

[Table("Orden")]
public partial class Orden
{
    [Key]
    [Column("IDOrden")]
    public int Idorden { get; set; }

    [Column("fecha", TypeName = "date")]
    public DateTime? Fecha { get; set; }

    [Column("IDUsuario")]
    public int? Idusuario { get; set; }

    //[InverseProperty("IdordenNavigation")]
    //public virtual ICollection<DetalleOrden> DetalleOrdenes { get; set; } = new List<DetalleOrden>();

    //[ForeignKey("Idusuario")]
    //[InverseProperty("Ordenes")]
    //public virtual Usuario? IdusuarioNavigation { get; set; }
}
