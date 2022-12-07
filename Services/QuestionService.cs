using qea_webapi.Models;
namespace qea_webapi.Services;

public class QuestionService : IQuestionService
{
    QeaContext context;

    public QuestionService(QeaContext context)
    {
        this.context = context;
    }

    public IEnumerable<Question> Get()
    {
        return context.Questions.ToList();
    }

    public async Task<Question> Create(Question question)
    {
        context.Questions.Add(question);
        await context.SaveChangesAsync();
        return question;
    }

    public async Task<Question> Update(Guid id, Question question)
    {
        var questionToUpdate = context.Questions.Find(id);
        if (questionToUpdate != null)
        {

            if (question.Statement != null)
            {
                questionToUpdate.Statement = question.Statement;
            }
            if (question.SubjectId.ToString() != "00000000-0000-0000-0000-000000000000")
            {
                questionToUpdate.SubjectId = question.SubjectId;
            }
            if (question.Visible != null)
            {
                questionToUpdate.Visible = question.Visible;
            }
            questionToUpdate.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return questionToUpdate;
        }
        else
        {
            return null;
        }
    }

    public async Task<Question> Delete(Guid id)
    {
        var questionToDelete = context.Questions.Find(id);
        if (questionToDelete != null)
        {
            context.Questions.Remove(questionToDelete);
            await context.SaveChangesAsync();
            return questionToDelete;
        }
        else
        {
            return null;
        }
    }
}

public interface IQuestionService
{
    IEnumerable<Question> Get();
    Task<Question> Create(Question question);
    Task<Question> Update(Guid id, Question question);
    Task<Question> Delete(Guid id);
}