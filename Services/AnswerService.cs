using qea_webapi.Models;
namespace qea_webapi.Services;

public class AnswerService : IAnswerService
{
    QeaContext context;

    public AnswerService(QeaContext context)
    {
        this.context = context;
    }

    public IEnumerable<Answer> Get()
    {
        return context.Answers.ToList();
    }

    public async Task<Answer> Create(Answer answer)
    {
        context.Answers.Add(answer);
        await context.SaveChangesAsync();
        return answer;
    }

    public async Task<Answer> Update(Guid id, Answer answer)
    {
        var answerToUpdate = context.Answers.Find(id);
        if (answerToUpdate != null)
        {

            if (answer.Statement != null)
            {
                answerToUpdate.Statement = answer.Statement;
            }
            if (answer.QuestionId != null)
            {
                answerToUpdate.QuestionId = answer.QuestionId;
            }
            if (answer.Visible != null)
            {
                answerToUpdate.Visible = answer.Visible;
            }
            answerToUpdate.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return answerToUpdate;
        }
        else
        {
            return null;
        }
    }

    public async Task<Answer> Delete(Guid id)
    {
        var answerToDelete = context.Answers.Find(id);
        if (answerToDelete != null)
        {
            context.Answers.Remove(answerToDelete);
            await context.SaveChangesAsync();
            return answerToDelete;
        }
        else
        {
            return null;
        }
    }
}

public interface IAnswerService
{
    IEnumerable<Answer> Get();
    Task<Answer> Create(Answer answer);
    Task<Answer> Update(Guid id, Answer answer);
    Task<Answer> Delete(Guid id);
}