namespace MoviesManagement.Data
{
    public class AgeLimit
    {
        public int AgeLimitId { get; set; }
        public string Description { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
