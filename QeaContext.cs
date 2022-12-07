namespace qea_webapi;

using Microsoft.EntityFrameworkCore;
using qea_webapi.Models;

public class QeaContext : DbContext
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Subject> Subjects { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<ExplanationNote> ExplanationNotes { get; set; } = null!;
    public DbSet<ExplanationVideo> ExplanationVideos { get; set; } = null!;
    public DbSet<Answer> Answers { get; set; } = null!;
    public QeaContext(DbContextOptions<QeaContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        List<Answer> answersInit = new List<Answer>();
        answersInit.Add(new Answer { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Statement = "Answer 1", QuestionId = Guid.Parse("00000000-0000-0001-0001-000000000001"), Visible = true, IsCorrect = true });
        answersInit.Add(new Answer { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Statement = "Answer 2", QuestionId = Guid.Parse("00000000-0000-0001-0001-000000000001"), Visible = true, IsCorrect = false });
        answersInit.Add(new Answer { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Statement = "Answer 3", QuestionId = Guid.Parse("00000000-0000-0001-0001-000000000001"), Visible = true, IsCorrect = false });
        answersInit.Add(new Answer { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Statement = "Answer 4", QuestionId = Guid.Parse("00000000-0000-0001-0001-000000000001"), Visible = true, IsCorrect = false });
        modelBuilder.Entity<Answer>(
            entity =>
            {
                entity.ToTable("answer");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Statement).IsRequired();
                entity.HasOne(e => e.Question).WithMany(e => e.Answers).HasForeignKey(e => e.QuestionId);
                entity.Property(e => e.Visible).HasDefaultValue(true);
                entity.Property(e => e.IsCorrect).IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()").ValueGeneratedOnAdd();
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

                entity.HasData(answersInit);
            }
        );

        List<Category> categoryInit = new List<Category>();
        categoryInit.Add(new Category { Id = Guid.Parse("00000001-0000-0000-0000-000000000001"), Name = "Category 1", Description = "Category 1 description", Visible = true });
        modelBuilder.Entity<Category>(
            entity =>
            {
                entity.ToTable("category");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(250);
                entity.Property(e => e.Visible).HasDefaultValue(true);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()").ValueGeneratedOnAdd();
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

                entity.HasData(categoryInit);
            }
        );

        List<Course> coursesInit = new List<Course>();
        coursesInit.Add(new Course { Id = Guid.Parse("00000002-0000-0000-0000-000000000001"), Name = "Course 1", Description = "Course 1 description", Visible = true, CategoryId = Guid.Parse("00000001-0000-0000-0000-000000000001") });
        modelBuilder.Entity<Course>(
            entity =>
            {
                entity.ToTable("course");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(250);
                entity.HasOne(e => e.Category).WithMany(e => e.Courses).HasForeignKey(e => e.CategoryId).IsRequired();
                entity.Property(e => e.Visible).HasDefaultValue(true);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()").ValueGeneratedOnAdd();
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

                entity.HasData(coursesInit);
            }
        );

        List<ExplanationNote> explanationNotesInit = new List<ExplanationNote>();
        explanationNotesInit.Add(new ExplanationNote { Id = Guid.Parse("00000003-0001-0000-0000-000000000001"), Url = "https://www.w3schools.com/images/w3schools_green.jpg", QuestionId = Guid.Parse("00000000-0000-0001-0001-000000000001"), Visible = true });
        modelBuilder.Entity<ExplanationNote>(
            entity =>
            {
                entity.ToTable("explanation_note");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Url).IsRequired();
                entity.HasOne(e => e.Question).WithMany(e => e.ExplanationNotes).HasForeignKey(e => e.QuestionId).IsRequired();
                entity.Property(e => e.Visible).HasDefaultValue(true);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()").ValueGeneratedOnAdd();
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

                entity.HasData(explanationNotesInit);
            }
        );

        List<ExplanationVideo> explanationVideosInit = new List<ExplanationVideo>();
        explanationVideosInit.Add(new ExplanationVideo { Id = Guid.Parse("00000003-0002-0000-0000-000000000001"), Url = "https://www.youtube.com/watch?v=1", QuestionId = Guid.Parse("00000000-0000-0001-0001-000000000001"), Visible = true });
        modelBuilder.Entity<ExplanationVideo>(
            entity =>
            {
                entity.ToTable("explanation_video");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Url).IsRequired();
                entity.HasOne(e => e.Question).WithMany(e => e.ExplanationVideos).HasForeignKey(e => e.QuestionId).IsRequired();
                entity.Property(e => e.Visible).HasDefaultValue(true);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()").ValueGeneratedOnAdd();
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

                entity.HasData(explanationVideosInit);
            }
        );

        List<Question> questionsInit = new List<Question>();
        questionsInit.Add(new Question { Id = Guid.Parse("00000000-0000-0001-0001-000000000001"), Statement = "Question 1", SubjectId = Guid.Parse("00000002-0000-0000-0000-000000000001"), Visible = true });
        modelBuilder.Entity<Question>(
            entity =>
            {
                entity.ToTable("question");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Statement).IsRequired();
                entity.HasOne(e => e.Subject).WithMany(e => e.Questions).HasForeignKey(e => e.SubjectId).IsRequired();
                entity.Property(e => e.Visible).HasDefaultValue(true);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()").ValueGeneratedOnAdd();
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

                entity.HasData(questionsInit);
            }
        );

        List<Subject> subjectsInit = new List<Subject>();
        subjectsInit.Add(new Subject { Id = Guid.Parse("00000002-0000-0000-0000-000000000001"), Name = "Subject 1", Description = "Subject 1 description", Visible = true, CourseId = Guid.Parse("00000002-0000-0000-0000-000000000001") });
        modelBuilder.Entity<Subject>(
            entity =>
            {
                entity.ToTable("subject");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(250);
                entity.HasOne(e => e.Course).WithMany(e => e.Subjects).HasForeignKey(e => e.CourseId).IsRequired();
                entity.Property(e => e.Visible).HasDefaultValue(true);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()").ValueGeneratedOnAdd();
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

                entity.HasData(subjectsInit);
            }
        );
    }
}