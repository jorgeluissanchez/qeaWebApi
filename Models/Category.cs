namespace qea_webapi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Category
{
    //[Key]
    public Guid Id { get; set; }
    //[Required(ErrorMessage = "Category name is required")]
    //[MaxLength(50, ErrorMessage = "Category name cannot be longer than 50 characters"), MinLength(3, ErrorMessage = "Category name cannot be shorter than 3 characters")]
    public string Name { get; set; } = null!;
    //[Required(ErrorMessage = "Category description is required")]
    //[MaxLength(250, ErrorMessage = "Category description cannot be longer than 250 characters"), MinLength(3, ErrorMessage = "Category description cannot be shorter than 3 characters")]
    public string Description { get; set; } = null!;
    //[Required(ErrorMessage = "Category visibility is required")]
    public bool Visible { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    [JsonIgnore]
    public virtual ICollection<Course> Courses { get; set; } = null!;
}