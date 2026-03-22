using CleanCity.Domain.Core;

namespace CleanCity.Domain.Entities
{
    public class Operator : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}