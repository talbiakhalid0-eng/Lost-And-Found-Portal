namespace Lost_And_Found_Portal.Components.Models
{
	public class Item
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;

		// These fields must be here so C# matches your SQL Database table columns
		public string Description { get; set; } = "No description provided.";
		public string Category { get; set; } = "General";
		public string Location { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = "/images/placeholder.png";

		public bool IsLost { get; set; }
		public string UserEmail { get; set; } = string.Empty;
		public string? ClaimedByEmail { get; set; }
		public string ClaimStatus { get; set; } = "Available";
	}
}