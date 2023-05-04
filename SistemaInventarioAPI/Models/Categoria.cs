using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventarioAPI.Models;

public partial class Categoria
{
    [Key]
    [Column("IDCategoria")]
    public int Idcategoria { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("descripcion")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    //[InverseProperty("IdcategoriaNavigation")]
    //public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
