using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nómina.Models
{
    public class Empleados
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        [Column(TypeName ="Decimal (18,2)")]
        public decimal Salario_Base { get; set; }
        [Column(TypeName = "Decimal (18,2)")]
        public decimal Deducciones { get; set; }
        [Column(TypeName ="Decimal (18,2)")]
        public decimal Bonificaciones { get; set; }
    }
}
