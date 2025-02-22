using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Models;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Controllers;

[ApiController]
[Route("tasks")]
public class TaskController : ControllerBase
{
    private readonly TaskService _taskService;

    public TaskController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_taskService.GetAllTasks());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var task = _taskService.GetTaskById(id);
        return task is not null ? Ok(task) : NotFound();
    }

    [HttpPost]
    public IActionResult Create(TaskItem task)
    {
        var newTask = _taskService.AddTask(task);
        return CreatedAtAction(nameof(GetById), new { id = newTask.Id }, newTask);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, TaskItem task)
    {
        var updatedTask = _taskService.UpdateTask(id, task);
        return updatedTask is not null ? Ok(updatedTask) : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) => _taskService.DeleteTask(id) ? NoContent() : NotFound();
}
