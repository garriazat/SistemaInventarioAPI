using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventarioAPI.Models;

[Table("Usuario")]
public partial class Usuario
{
    [Key]
    [Column("IDUsuario")]
    public int Idusuario { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("correo")]
    [StringLength(40)]
    [Unicode(false)]
    public string? Correo { get; set; }

    [Column("contrasena")]
    [StringLength(40)]
    [Unicode(false)]
    public string? Contrasena { get; set; }

    //[InverseProperty("IdusuarioNavigation")]
    //public virtual ICollection<Orden> Ordenes { get; set; } = new List<Orden>();
}
