using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Username { get; set; }

    [Required]
    [StringLength(300)]
    public string Password { get; set; }
}