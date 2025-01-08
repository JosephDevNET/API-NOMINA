namespace Nómina.DTOs
{
    public class EmpleadoUpdateDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public decimal Salario_Base { get; set; }
        public decimal Bonificaciones { get; set; }
    }
}
