namespace qea_webapi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Question
{
    //[Key]
    public Guid Id { get; set; }
    //[Required(ErrorMessage = "Question statement is required")]
    public string Statement { get; set; } = null!;
    //[Required(ErrorMessage = "Question subject is required")]
    //[ForeignKey("Subject")]
    public Guid SubjectId { get; set; }
    //[Required(ErrorMessage = "Question visibility is required")]
    public bool Visible { get; set; }

    public virtual Subject Subject { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Answer> Answers { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<ExplanationNote> ExplanationNotes { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<ExplanationVideo> ExplanationVideos { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}