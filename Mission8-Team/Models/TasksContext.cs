using Microsoft.EntityFrameworkCore;

namespace Mission8_Team.Models;

public class TasksContext : DbContext
{
    public TasksContext(DbContextOptions<TasksContext> options) : base(options)
    {
    }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryID = 1, CategoryName = "Home" },
            new Category { CategoryID = 2, CategoryName = "School" },
            new Category { CategoryID = 3, CategoryName = "Work" },
            new Category { CategoryID = 4, CategoryName = "Church" }
        );
    }
}