using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using TodoApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
const string connectionString = "Server=localhost;Database=todolist;User=root;Password=password;";
var connection = new MySqlConnection(connectionString);
builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString(connectionString)));
await connection.OpenAsync();
builder.Services.AddDbContext<ApplicationDbContext>((options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 35)))));
//var command = new MySqlCommand("INSERT INTO todolist.users VALUES (2, 'Kartew2', 'pasw2');", connection);
//var reader = await command.ExecuteNonQueryAsync();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();