namespace qea_webapi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Course
{
    //[Key]
    public Guid Id { get; set; }
    //[Required(ErrorMessage = "Course name is required")]
    //[MaxLength(50, ErrorMessage = "Course name cannot be longer than 50 characters"), MinLength(3, ErrorMessage = "Course name cannot be shorter than 3 characters")]
    public string Name { get; set; } = null!;
    //[Required(ErrorMessage = "Course description is required")]
    //[MaxLength(250, ErrorMessage = "Course description cannot be longer than 250 characters"), MinLength(3, ErrorMessage = "Course description cannot be shorter than 3 characters")]
    public string Description { get; set; } = null!;
    //[Required(ErrorMessage = "Course category is required")]
    //[ForeignKey("Category")]
    public Guid CategoryId { get; set; }
    //[Required(ErrorMessage = "Course visibility is required")]
    public bool Visible { get; set; }
    public virtual Category Category { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Subject> Subjects { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}