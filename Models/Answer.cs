namespace qea_webapi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Answer
{
    //[Key]
    public Guid Id { get; set; }
    //[Required(ErrorMessage = "Answer statement is required")]
    public string Statement { get; set; } = null!;
    //[Required(ErrorMessage = "Answer question is required")]
    //[ForeignKey("Question")]
    public Guid QuestionId { get; set; }
    //[Required(ErrorMessage = "Answer visibility is required")]
    public bool Visible { get; set; }
    public bool IsCorrect { get; set; }

    public virtual Question Question { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}