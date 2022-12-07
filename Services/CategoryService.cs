using qea_webapi.Models;
namespace qea_webapi.Services;

public class CategoryService : ICategoryService
{
    QeaContext context;

    public CategoryService(QeaContext context)
    {
        this.context = context;
    }

    public IEnumerable<Category> Get()
    {
        return context.Categories.ToList();
    }

    public async Task<Category> Create(Category category)
    {
        context.Categories.Add(category);
        await context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Update(Guid id, Category category)
    {
        var categoryToUpdate = context.Categories.Find(id);
        if (categoryToUpdate != null)
        {

            if (category.Name != null)
            {
                categoryToUpdate.Name = category.Name;
            }
            if (category.Description != null)
            {
                categoryToUpdate.Description = category.Description;
            }
            if (category.Visible != null)
            {
                categoryToUpdate.Visible = category.Visible;
            }
            categoryToUpdate.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return categoryToUpdate;
        }
        else
        {
            return null;
        }
    }

    public async Task<Category> Delete(Guid id)
    {
        var categoryToDelete = context.Categories.Find(id);
        if (categoryToDelete != null)
        {
            context.Categories.Remove(categoryToDelete);
            await context.SaveChangesAsync();
            return categoryToDelete;
        }
        else
        {
            return null;
        }
    }
}

public interface ICategoryService
{
    IEnumerable<Category> Get();
    Task<Category> Create(Category category);
    Task<Category> Update(Guid id, Category category);
    Task<Category> Delete(Guid id);
}