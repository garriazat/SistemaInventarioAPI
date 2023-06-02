using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventarioAPI.Models;

[Table("Bitacora")]
public partial class Bitacora
{
    [Key]
    [Column("IDBitacora")]
    public int Idbitacora { get; set; }

    [Column("fecha", TypeName = "date")]
    public DateTime? Fecha { get; set; }

    [Column("hora")]
    public TimeSpan? Hora { get; set; }

    [Column("producto")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Producto { get; set; }

    [Column("cantidad")]
    public int? Cantidad { get; set; }

    [Column("transaccion")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Transaccion { get; set; }
}
