using qea_webapi.Models;
namespace qea_webapi.Services;

public class ExplanationVideoService : IExplanationVideoService
{
    QeaContext context;

    public ExplanationVideoService(QeaContext context)
    {
        this.context = context;
    }

    public IEnumerable<ExplanationVideo> Get()
    {
        return context.ExplanationVideos.ToList();
    }

    public async Task<ExplanationVideo> Create(ExplanationVideo explanationVideo)
    {
        context.ExplanationVideos.Add(explanationVideo);
        await context.SaveChangesAsync();
        return explanationVideo;
    }

    public async Task<ExplanationVideo> Update(Guid id, ExplanationVideo explanationVideo)
    {
        var explanationVideoToUpdate = context.ExplanationVideos.Find(id);
        if (explanationVideoToUpdate != null)
        {

            if (explanationVideo.Url != null)
            {
                explanationVideoToUpdate.Url = explanationVideo.Url;
            }
            if (explanationVideo.QuestionId.ToString() != "00000000-0000-0000-0000-000000000000")
            {
                explanationVideoToUpdate.QuestionId = explanationVideo.QuestionId;
            }
            if (explanationVideo.Visible != null)
            {
                explanationVideoToUpdate.Visible = explanationVideo.Visible;
            }
            explanationVideoToUpdate.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return explanationVideoToUpdate;
        }
        else
        {
            return null;
        }
    }

    public async Task<ExplanationVideo> Delete(Guid id)
    {
        var explanationVideoToDelete = context.ExplanationVideos.Find(id);
        if (explanationVideoToDelete != null)
        {
            context.ExplanationVideos.Remove(explanationVideoToDelete);
            await context.SaveChangesAsync();
            return explanationVideoToDelete;
        }
        else
        {
            return null;
        }
    }
}

public interface IExplanationVideoService
{
    IEnumerable<ExplanationVideo> Get();
    Task<ExplanationVideo> Create(ExplanationVideo explanationVideo);
    Task<ExplanationVideo> Update(Guid id, ExplanationVideo explanationVideo);
    Task<ExplanationVideo> Delete(Guid id);
}