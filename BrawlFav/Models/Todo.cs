namespace BrawlFav.Models
{

    public enum TodoStatus
    {
        DONE,
        IN_PROGRESS,
        IN_QUEUE
    }

    public class Todo
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required TodoStatus Status { get; set; }

    }
}
