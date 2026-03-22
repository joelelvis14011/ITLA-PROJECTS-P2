using CleanCity.Domain.Core;

namespace CleanCity.Domain.Entities
{
    public class Collection : BaseEntity
    {
        public int RouteId { get; set; }
        public int OperatorId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal Tons { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        // Navegación
        public C_route Route { get; set; }
        public Operator Operator { get; set; }
    }
}