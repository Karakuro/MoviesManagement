namespace MoviesManagement.Data
{
    public class Technology
    {
        public int TechnologyId { get; set; }
        public string Name { get; set; }
        public string TechnologyType { get; set; }
        public List<Room>? Rooms { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
