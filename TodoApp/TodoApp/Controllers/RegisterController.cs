using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySqlConnector;
using TodoApp.Data;
using TodoApp.Models;
using BCrypt.Net;

namespace TodoApp.Controllers;

public class RegisterController : Controller
{
    private readonly ApplicationDbContext _context;

    public RegisterController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(User model)
    {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

            // Create a new User object with the hashed password.
            var user = new User
            {
                Username = model.Username,
                Password = hashedPassword
            };

            // Add the user to the DbContext and save changes to the database.
            _context.Users.Add(user);
            try
            {
                // Database operation
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception and any relevant information
                Console.WriteLine(ex);
                throw; // Rethrow the exception for proper error handling.
            }
            Console.WriteLine("tets");
        return View(model);
    }
}