using CleanCity.Domain.Core;

namespace CleanCity.Domain.Entities
{
    public class C_route : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Zone { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}