namespace MoviesManagement.Data
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int CleanTimeMins { get; set; }
        public List<Projection>? Projections { get; set; }
        public List<Technology>? Technologies { get; set; }
    }
}
