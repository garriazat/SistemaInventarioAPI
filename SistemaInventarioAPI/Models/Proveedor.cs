using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventarioAPI.Models;

[Table("Proveedor")]
public partial class Proveedor
{
    [Key]
    [Column("IDProveedor")]
    public int Idproveedor { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("persona_contacto")]
    [StringLength(100)]
    [Unicode(false)]
    public string? PersonaContacto { get; set; }

    [Column("telefono_contacto")]
    [StringLength(20)]
    [Unicode(false)]
    public string? TelefonoContacto { get; set; }

    [Column("correo_contacto")]
    [StringLength(40)]
    [Unicode(false)]
    public string? CorreoContacto { get; set; }

    //[InverseProperty("IdproveedorNavigation")]
    //public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
