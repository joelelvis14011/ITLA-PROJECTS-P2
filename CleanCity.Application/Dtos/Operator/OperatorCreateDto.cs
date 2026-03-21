namespace CleanCity.Application.Dtos.Operator
{
    public class OperatorCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}