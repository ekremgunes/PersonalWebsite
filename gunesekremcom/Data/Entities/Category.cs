namespace gunesekremcom.Data.Entities
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public List<Post> Posts { get; set; }
    }
}
