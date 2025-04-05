using System.ComponentModel.DataAnnotations;

namespace MyProject.API.Models.Dto
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
