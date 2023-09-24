namespace Integrador.DTOs
{
    public class TrabajoDTO
    {
        public int IdTrabajo { get; set; }
        public DateTime Fecha { get; set; }
        public int CantHoras { get; set; }
        public double ValorHora { get; set; }
        public double Costo { get; set; }
        public int IdProyecto { get; set; }
        public int IdServicio { get; set; }
    }
}
