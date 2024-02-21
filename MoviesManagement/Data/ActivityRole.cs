namespace MoviesManagement.Data
{
    public class ActivityRole
    {
        public int ActivityRoleId { get; set; }
        public string Description { get; set; }
        public List<ProjectionActivity>? Activities { get; set; }
    }
}
