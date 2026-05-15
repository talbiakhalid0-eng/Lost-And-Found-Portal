using System.ComponentModel.DataAnnotations;
namespace Lost_And_Found_Portal.Components.Models
{
    public class RegisterModel
    {
		[Required(ErrorMessage = "University email is required")]
		[EmailAddress(ErrorMessage = "Invalid email format")]
		[Display(Name = "University Email")]
		// This Regex ensures the email ends EXACTLY with @mail.au.edu.pk
		[RegularExpression(@"^[a-zA-Z0-9._%+-]+@mail\.au\.edu\.pk$",
			ErrorMessage = "Access denied. You must use your official AU student email (@mail.au.edu.pk).")]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "Password is required")]
		[MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
		[DataType(DataType.Password)]
		public string Password { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please confirm your password")]
		[Compare("Password", ErrorMessage = "Passwords do not match")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; } = string.Empty;
     }
}
