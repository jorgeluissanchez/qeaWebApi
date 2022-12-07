namespace qea_webapi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ExplanationVideo
{
    //[Key]
    public Guid Id { get; set; }
    //[Required(ErrorMessage = "Explanation video url is required")]
    public string Url { get; set; } = null!;
    //[Required(ErrorMessage = "Explanation video question is required")]
    //[ForeignKey("Question")]
    public Guid QuestionId { get; set; }
    //[Required(ErrorMessage = "Explanation video visibility is required")]
    public bool Visible { get; set; }

    public virtual Question Question { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}