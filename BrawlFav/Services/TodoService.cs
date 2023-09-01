using BrawlFav.DTOs;
using BrawlFav.Models;
using BrawlFav.Services.BrawlFav.Services;

namespace BrawlFav.Services;

public class TodorService : ITodoService
{
    private static List<Todo> Todos { get; } = new List<Todo>();
    private static int CountId { get; set; } = 1;



    public List<Todo> GetAll() => Todos;

    public Todo Create(CreateTodoDTO dto)
    {
        Todo todo = new()
        {
            Id = CountId,
            Description = dto.Description,
            Status = TodoStatus.IN_QUEUE
        };
        Todos.Add(todo);
        CountId++;

        return todo;
    }

    public Todo? Get(int Id) => Todos.Find(b => b.Id == Id);

    public int Update(int id, UpdateTodoDTO dto)
    {
        var todoIndex = Todos.FindIndex(b => b.Id == id);

        if (todoIndex == -1) return -1;

        Todos[todoIndex].Status = dto.Status;

        return Todos[todoIndex].Id;
    }

    public int Delete(int Id)
    {
        var brawlerIndex = Todos.FindIndex(b => b.Id == Id);
        if (brawlerIndex == -1) return -1;
        Todos.RemoveAt(brawlerIndex);
        return 1;
    }
}