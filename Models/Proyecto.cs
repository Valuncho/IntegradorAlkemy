namespace Integrador.Models
{
    public class Proyecto
    {
        
    public int CodProyecto { get; set; }
        public string Nombre { get; set; }
        public string Dirección { get; set; }
        public int Estado { get; set; }

        // diccionario para saber el estado
        private static readonly Dictionary<int, string> Estados = new Dictionary<int, string>
    {
        { 1, "Pendiente" },
        { 2, "Confirmado" },
        { 3, "Terminado" },
    };

        public Proyecto(int codProyecto, string nombre, string dirección, int estado)
        {
            CodProyecto = codProyecto;
            Nombre = nombre;
            Dirección = dirección;
            Estado = estado;
        }

        public string ObtenerEstadoProyecto()
        {
            if (Estados.TryGetValue(Estado, out string estadoStr))
            {
                return estadoStr;
            }
            return "Desconocido";
        }
    }
}
