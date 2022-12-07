using qea_webapi.Models;
namespace qea_webapi.Services;

public class ExplanationNoteService : IExplanationNoteService
{
    QeaContext context;

    public ExplanationNoteService(QeaContext context)
    {
        this.context = context;
    }

    public IEnumerable<ExplanationNote> Get()
    {
        return context.ExplanationNotes.ToList();
    }

    public async Task<ExplanationNote> Create(ExplanationNote explanationNote)
    {
        context.ExplanationNotes.Add(explanationNote);
        await context.SaveChangesAsync();
        return explanationNote;
    }

    public async Task<ExplanationNote> Update(Guid id, ExplanationNote explanationNote)
    {
        var explanationNoteToUpdate = context.ExplanationNotes.Find(id);
        if (explanationNoteToUpdate != null)
        {

            if (explanationNote.Url != null)
            {
                explanationNoteToUpdate.Url = explanationNote.Url;
            }
            if (explanationNote.QuestionId.ToString() != "00000000-0000-0000-0000-000000000000")
            {
                explanationNoteToUpdate.QuestionId = explanationNote.QuestionId;
            }
            if (explanationNote.Visible != null)
            {
                explanationNoteToUpdate.Visible = explanationNote.Visible;
            }
            explanationNoteToUpdate.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return explanationNoteToUpdate;
        }
        else
        {
            return null;
        }
    }

    public async Task<ExplanationNote> Delete(Guid id)
    {
        var explanationNoteToDelete = context.ExplanationNotes.Find(id);
        if (explanationNoteToDelete != null)
        {
            context.ExplanationNotes.Remove(explanationNoteToDelete);
            await context.SaveChangesAsync();
            return explanationNoteToDelete;
        }
        else
        {
            return null;
        }
    }
}

public interface IExplanationNoteService
{
    IEnumerable<ExplanationNote> Get();
    Task<ExplanationNote> Create(ExplanationNote explanationNote);
    Task<ExplanationNote> Update(Guid id, ExplanationNote explanationNote);
    Task<ExplanationNote> Delete(Guid id);
}