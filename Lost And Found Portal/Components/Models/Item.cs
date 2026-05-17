namespace Lost_And_Found_Portal.Components.Models
{
	public class Item
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string? Description { get; set; }
		public string? Category { get; set; }
		public string Location { get; set; } = string.Empty;
		public string ContactInfo { get; set; } = string.Empty;
		public string? ImageUrl { get; set; }
		public bool IsLost { get; set; }
		public string UserEmail { get; set; } = string.Empty;
		public string ClaimStatus { get; set; } = "Available"; // Available, PendingApproval, Claimed
		public string? ClaimedByEmail { get; set; }
		public string? ClaimProofOfOwnership { get; set; }
		public bool IsNotificationPending { get; set; } = false;
	}
}