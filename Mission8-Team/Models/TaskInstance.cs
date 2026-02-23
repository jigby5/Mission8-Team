using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission8_Team.Models;

public class TaskInstance
{
    [Key]
    [Required]
    public int TaskId { get; set; }
    
    [Required]
    public string TaskName { get; set; }
    
    public DateTime DueDate { get; set; }
    
    [Required]
    [Range(1, 4)]
    public int Quadrant { get; set; }
    
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public bool Completed { get; set; }
}