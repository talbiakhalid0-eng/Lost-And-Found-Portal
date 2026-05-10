using Lost_And_Found_Portal.Components.	Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lost_And_Found_Portal.Components.Data
{
    public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) { }

		public DbSet<Item> Items { get; set; }
	}
}
