using qea_webapi.Models;
namespace qea_webapi.Services;

public class SubjectService : ISubjectService
{
    QeaContext context;

    public SubjectService(QeaContext context)
    {
        this.context = context;
    }

    public IEnumerable<Subject> Get()
    {
        return context.Subjects.ToList();
    }

    public async Task<Subject> Create(Subject subject)
    {
        context.Subjects.Add(subject);
        await context.SaveChangesAsync();
        return subject;
    }

    public async Task<Subject> Update(Guid id, Subject subject)
    {
        var subjectToUpdate = context.Subjects.Find(id);
        if (subjectToUpdate != null)
        {

            if (subject.Name != null)
            {
                subjectToUpdate.Name = subject.Name;
            }
            if (subject.Description != null)
            {
                subjectToUpdate.Description = subject.Description;
            }
            if (subject.CourseId.ToString() != "00000000-0000-0000-0000-000000000000")
            {
                subjectToUpdate.CourseId = subject.CourseId;
            }
            if (subject.Visible != null)
            {
                subjectToUpdate.Visible = subject.Visible;
            }
            subjectToUpdate.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return subjectToUpdate;
        }
        else
        {
            return null;
        }
    }

    public async Task<Subject> Delete(Guid id)
    {
        var subjectToDelete = context.Subjects.Find(id);
        if (subjectToDelete != null)
        {
            context.Subjects.Remove(subjectToDelete);
            await context.SaveChangesAsync();
            return subjectToDelete;
        }
        else
        {
            return null;
        }
    }
}
public interface ISubjectService
{
    IEnumerable<Subject> Get();
    Task<Subject> Create(Subject subject);
    Task<Subject> Update(Guid id, Subject subject);
    Task<Subject> Delete(Guid id);
}