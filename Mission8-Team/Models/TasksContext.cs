using Microsoft.EntityFrameworkCore;

namespace Mission8_Team.Models;

public class TasksContext : DbContext
{
    public TasksContext(DbContextOptions<TasksContext> options) : base(options)
    {
    }
    public DbSet<TaskInstance> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Home" },
            new Category { CategoryId = 2, CategoryName = "School" },
            new Category { CategoryId = 3, CategoryName = "Work" },
            new Category { CategoryId = 4, CategoryName = "Church" }
        );

        modelBuilder.Entity<TaskInstance>().HasData(
            new TaskInstance { TaskId = 1, TaskName = "Finish homework", Quadrant = 1, CategoryId = 2, Completed = false, DueDate = DateTime.Today.AddDays(1) },
            new TaskInstance { TaskId = 2, TaskName = "Plan week", Quadrant = 2, CategoryId = 2, Completed = false, DueDate = DateTime.Today.AddDays(7) },
            new TaskInstance { TaskId = 3, TaskName = "Email back", Quadrant = 3, CategoryId = 3, Completed = false, DueDate = DateTime.Today.AddDays(2) }
        );
    }
}