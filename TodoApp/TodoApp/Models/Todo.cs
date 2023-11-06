using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models;

public class Todo
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(10)]
    public string Name { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Content { get; set; }
    
    [StringLength(10)]
    public string Date { get; set; }
}