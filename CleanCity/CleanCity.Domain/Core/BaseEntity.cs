using System.ComponentModel.DataAnnotations;

namespace CleanCity.Domain.Core
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
