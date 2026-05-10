namespace Lost_And_Found_Portal.Components.Models
{
    public class Item : BaseEntity
	{
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Category { get; set; } = "General";
		public string Location { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = "/images/placeholder.png";
		public bool IsLost { get; set; } // True = Lost, False = Found
		public string Status { get; set; } = "Unclaimed";
		public string ContactInfo { get; set; } = string.Empty;
		public string UserId { get; set; } = string.Empty;
	}
}
