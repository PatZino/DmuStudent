using Microsoft.EntityFrameworkCore;

namespace DmuStudent.Models
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Student> Members { get; set; }
	}
}
