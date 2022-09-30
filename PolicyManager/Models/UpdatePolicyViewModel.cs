namespace PolicyManager.Models
{
	public class UpdatePolicyViewModel
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Premium { get; set; }
    }
}
