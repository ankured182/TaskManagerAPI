using TaskManagerAPI.Models;

namespace TaskManagerAPI.Repositories;

public interface ITaskRepository
{
    IEnumerable<TaskItem> GetAll();
    TaskItem? GetById(int id);
    TaskItem Add(TaskItem task);
    TaskItem? Update(int id, TaskItem task);
    bool Delete(int id);
}
