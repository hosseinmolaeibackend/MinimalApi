using Microsoft.EntityFrameworkCore;
using minimalApi.Model;

namespace minimalApi.AppDb
{
	public class AppDBContext(DbContextOptions<AppDBContext> option) : DbContext(option)
	{
		public DbSet<TodoModel> todoModels { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);


		}
	}
}
