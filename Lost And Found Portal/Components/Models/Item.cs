using System.ComponentModel.DataAnnotations;

namespace Lost_And_Found_Portal.Components.Models
{
	public class Item
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Please provide a short descriptive title for the item.")]
		[StringLength(50, ErrorMessage = "The item title cannot exceed 50 characters.")]
		public string Title { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please specify where the item was lost or found on campus.")]
		public string Location { get; set; } = string.Empty;
		public bool IsLost { get; set; } = true;
		public string? ImageUrl { get; set; }
		public string? UserEmail { get; set; }
		public bool IsApproved { get; set; } = false;
		public string? ClaimedByEmail { get; set; }
		public string? ClaimStatus { get; set; }
	}
}