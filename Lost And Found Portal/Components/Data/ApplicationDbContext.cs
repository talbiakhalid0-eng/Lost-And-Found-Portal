using Microsoft.EntityFrameworkCore;
using Lost_And_Found_Portal.Components.Models;

namespace Lost_And_Found_Portal.Components.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Item> Items { get; set; }
		public DbSet<User> Users { get; set; }
	}
}