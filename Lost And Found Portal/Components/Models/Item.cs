namespace Lost_And_Found_Portal.Components.Models
{
	public class Item
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public string? Category { get; set; }
		public string? Location { get; set; }
		public string? ImageUrl { get; set; }
		public bool IsLost { get; set; }
		public string? UserEmail { get; set; }
		public string? ClaimedByEmail { get; set; }
		public string? ClaimStatus { get; set; }
	}
}