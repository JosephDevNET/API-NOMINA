using System.ComponentModel.DataAnnotations.Schema;

namespace Nómina.DTOs
{
    public class EmpleadoDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public decimal Salario_Base { get; set; }
        public decimal Deducciones { get; set; }
        public decimal Bonificaciones { get; set; }
    }
}
