namespace BrawlFav.Services
{

    using global::BrawlFav.DTOs;
    using global::BrawlFav.Models;
    using System.Collections.Generic;


    namespace BrawlFav.Services
    {
        public interface ITodoService
        {
            List<Todo> GetAll();
            Todo Create(CreateTodoDTO dto);
            Todo? Get(int Id);
            int Update(int Id, UpdateTodoDTO dto);
            int Delete(int Id);
        }
    }
}