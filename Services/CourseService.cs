using qea_webapi.Models;
namespace qea_webapi.Services;

public class CourseService : ICourseService
{
    QeaContext context;

    public CourseService(QeaContext context)
    {
        this.context = context;
    }

    public IEnumerable<Course> Get()
    {
        return context.Courses.ToList();
    }

    public async Task<Course> Create(Course course)
    {
        context.Courses.Add(course);
        await context.SaveChangesAsync();
        return course;
    }

    public async Task<Course> Update(Guid id, Course course)
    {
        var courseToUpdate = context.Courses.Find(id);
        if (courseToUpdate != null)
        {

            if (course.Name != null)
            {
                courseToUpdate.Name = course.Name;
            }
            if (course.Description != null)
            {
                courseToUpdate.Description = course.Description;
            }
            if (course.Visible != null)
            {
                courseToUpdate.Visible = course.Visible;
            }
            courseToUpdate.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return courseToUpdate;
        }
        else
        {
            return null;
        }
    }

    public async Task<Course> Delete(Guid id)
    {
        var courseToDelete = context.Courses.Find(id);
        if (courseToDelete != null)
        {
            context.Courses.Remove(courseToDelete);
            await context.SaveChangesAsync();
            return courseToDelete;
        }
        else
        {
            return null;
        }
    }
}

public interface ICourseService
{
    IEnumerable<Course> Get();
    Task<Course> Create(Course course);
    Task<Course> Update(Guid id, Course course);
    Task<Course> Delete(Guid id);
}