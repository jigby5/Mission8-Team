using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission8_Team.Models;

public class Task
{
    [Key]
    [Required]
    public int TaskId { get; set; }
    
    [Required]
    public string TaskName { get; set; }
    
    public DateTime DueDate { get; set; }
    
    [Required]
    public string Quadrant { get; set; }
    
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public bool Completed { get; set; }
}