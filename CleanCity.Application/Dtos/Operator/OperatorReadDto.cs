namespace CleanCity.Application.Dtos.Operator
{
    public class OperatorReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
