namespace Integrador.DTOs
{
    public class JobDTO
    {
        public int JobId { get; set; }
        public DateTime Date { get; set; }
        public int HoursWorked { get; set; }
        public double ValueTime { get; set; }
        public double Cost { get; set; }
        public int ProjectId { get; set; }
        public int ServiceId { get; set; }
    }
}
