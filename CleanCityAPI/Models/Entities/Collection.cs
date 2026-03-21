namespace CleanCityAPI.Models.Entities
{
    public class Collection
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int OperatorId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal Tons { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }

}
