namespace Integrador.Models
{
    public class Servicio
    {
        public int CodServicio { get; set; }
        public string Descr { get; set; }
        public bool Estado { get; set; }
        public decimal ValorHora { get; set; }

        public Servicio(int codServicio, string descr, bool estado, decimal valorHora)
        {
            CodServicio = codServicio;
            Descr = descr;
            Estado = estado;
            ValorHora = valorHora;
        }

        public void ActivarServicio()
        {
            Estado = true;
        }

        public void DesactivarServicio()
        {
            Estado = false;
        }
    }
}
