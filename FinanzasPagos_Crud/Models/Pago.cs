using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanzasPagos_Crud.Models
{
    [Table("pagos")]
    public class Pago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Column("monto", TypeName = "decimal(10,2)")]
        [Display(Name = "Monto (S/.)")]
        [Range(0.01, 9999999.99, ErrorMessage = "El monto debe ser mayor a 0.")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [Column("estado", TypeName = "varchar(20)")]
        [Display(Name = "Estado")]
        public EstadoPago Estado { get; set; } = EstadoPago.Pendiente;

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        [Column("categoria", TypeName = "varchar(20)")]
        [Display(Name = "Categoría")]
        public CategoriaPago Categoria { get; set; } = CategoriaPago.Pago;

        [Column("creado_en")]
        [Display(Name = "Fecha de registro")]
        public DateTime CreadoEn { get; set; } = DateTime.UtcNow;
    }

    public enum EstadoPago
    {
        [Display(Name = "Pendiente")]
        Pendiente,
        [Display(Name = "Aprobado")]
        Aprobado
    }

    public enum CategoriaPago
    {
        [Display(Name = "Pago")]
        Pago,
        [Display(Name = "Gasto")]
        Gasto
    }
}