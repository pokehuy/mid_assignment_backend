using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mid_assignment_backend.Models
{
    public class CategoryModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }
}