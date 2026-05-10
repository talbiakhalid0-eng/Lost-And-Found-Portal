namespace Lost_And_Found_Portal.Components.Models
{
	public abstract class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public bool IsActive { get; set; } = true;
	}
}
