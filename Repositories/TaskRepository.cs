using TaskManagerAPI.Models;

namespace TaskManagerAPI.Repositories;

public class TaskRepository : ITaskRepository
{
    
    private readonly List<TaskItem> _tasks = new()
    {
        new TaskItem { Id = 1, Name = "11 Learn C#", IsCompleted = false },
        new TaskItem { Id = 2, Name = "22 Build Task Manager API", IsCompleted = false },
        new TaskItem { Id = 3, Name = "33 Build Task Manager API", IsCompleted = false }
    };


        // ✅ Constructor: Log tasks when repository is created
        public TaskRepository()
        {
            Console.WriteLine("Initializing TaskRepository with tasks:");
            foreach (var task in _tasks)
            {
                Console.WriteLine($"- {task.Id}: {task.Name}");
            }
        }
    public IEnumerable<TaskItem> GetAll() => _tasks;

    public TaskItem? GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);

    public TaskItem Add(TaskItem task)
    {
        task.Id = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
        _tasks.Add(task);
        return task;
    }

    public TaskItem? Update(int id, TaskItem task)
    {
        var existingTask = _tasks.FirstOrDefault(t => t.Id == id);
        if (existingTask is null) return null;

        existingTask.Name = task.Name;
        existingTask.IsCompleted = task.IsCompleted;
        return existingTask;
    }

    public bool Delete(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task is null) return false;

        _tasks.Remove(task);
        return true;
    }
}
