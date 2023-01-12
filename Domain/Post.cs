namespace Domain
{
    public class Post
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string VideoLink { get; set; }
        public bool IsHide { get; set; }
        public long TotalsLike { get; set; }
        public long TotalsShare { get; set; }
        public long TotalsComment { get; set; }
    }
}

