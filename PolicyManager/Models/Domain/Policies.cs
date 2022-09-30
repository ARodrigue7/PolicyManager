namespace PolicyManager.Models.Domain
{
    public class Policies
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Premium { get; set; }  
    }
}
