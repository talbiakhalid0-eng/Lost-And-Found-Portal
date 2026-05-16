namespace Lost_And_Found_Portal.Components.Models
{
	public class Item
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Location { get; set; } = string.Empty;
		public bool IsLost { get; set; } = true;
		public string? ImageUrl { get; set; }
		public string? UserEmail { get; set; }
		public bool IsApproved { get; set; } = false;
		public string? ClaimedByEmail { get; set; }
		public string? ClaimStatus { get; set; }
	}
}