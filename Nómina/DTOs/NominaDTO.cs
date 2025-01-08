namespace Nómina.DTOs
{
    public class NominaDTO
    {
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public decimal Salario_Base { get; set; }
        public decimal Deducciones { get; set; }
        public decimal Bonificaciones { get; set; }
        public decimal Nomina { get; set; }
    }
}
