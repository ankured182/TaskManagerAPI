using TaskManagerAPI.Models;
using TaskManagerAPI.Repositories;

namespace TaskManagerAPI.Services;

public class TaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public IEnumerable<TaskItem> GetAllTasks() => _taskRepository.GetAll();

    public TaskItem? GetTaskById(int id) => _taskRepository.GetById(id);

    public TaskItem AddTask(TaskItem task) => _taskRepository.Add(task);

    public TaskItem? UpdateTask(int id, TaskItem task) => _taskRepository.Update(id, task);

    public bool DeleteTask(int id) => _taskRepository.Delete(id);
}
