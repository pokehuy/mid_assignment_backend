using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mid_assignment_backend.Entities
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}