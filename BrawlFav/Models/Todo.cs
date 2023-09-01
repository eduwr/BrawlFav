namespace BrawlFav.Models
{

    public enum TodoStatus
    {
        IN_QUEUE,
        IN_PROGRESS,
        DONE,
    }

    public class Todo
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required TodoStatus Status { get; set; }

    }
}
