using TaskManagerAPI.Repositories;
using TaskManagerAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Register dependencies for DI
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
builder.Services.AddSingleton<TaskService>();

// Add controllers
builder.Services.AddControllers();

var app = builder.Build();

// Enable controllers
app.MapControllers();

app.Run();
