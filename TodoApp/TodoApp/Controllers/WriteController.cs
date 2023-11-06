using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers;

public class WriteController : Controller
{
    private readonly ApplicationDbContext _context;

    public WriteController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult DisplayTodos()
    {
        List<Todo> todos = _context.Todos.ToList();
        return View(todos);
    }
    [HttpPost]
    public async Task<IActionResult> Write(Todo model)
    {
        var todo = new Todo
        {
            Name = model.Name,
            Content = model.Content,
            Date = model.Date
        };
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();
        List<Todo> todos = _context.Todos.ToList();
        return View(todos);
    }
}