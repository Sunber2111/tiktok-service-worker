namespace Application.Posts.DTO
{
    public class PostDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string VideoLink { get; set; }
        public bool IsHide { get; set; }
    }
}

