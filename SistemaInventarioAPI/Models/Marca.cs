using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventarioAPI.Models;

[Table("Marca")]
public partial class Marca
{
    [Key]
    [Column("IDMarca")]
    public int Idmarca { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [InverseProperty("IdmarcaNavigation")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
