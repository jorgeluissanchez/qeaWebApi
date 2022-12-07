namespace qea_webapi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Subject
{
    //[Key]
    public Guid Id { get; set; }
    //[Required(ErrorMessage = "Subject name is required")]
    //[MaxLength(50, ErrorMessage = "Subject name cannot be longer than 50 characters"), MinLength(3, ErrorMessage = "Subject name cannot be shorter than 3 characters")]
    public string Name { get; set; } = null!;
    //[Required(ErrorMessage = "Subject description is required")]
    //[MaxLength(250, ErrorMessage = "Subject description cannot be longer than 250 characters"), MinLength(3, ErrorMessage = "Subject description cannot be shorter than 3 characters")]
    public string Description { get; set; } = null!;
    //[Required(ErrorMessage = "Subject course is required")]
    //[ForeignKey("Course")]
    public Guid CourseId { get; set; }
    //[Required(ErrorMessage = "Subject visibility is required")]
    public bool Visible { get; set; }
    public virtual Course Course { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Question> Questions { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}