using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using minimalApi.Model;

namespace minimalApi.Configurations
{
	public class TodoConfiguration : IEntityTypeConfiguration<TodoModel>
	{
		public void Configure(EntityTypeBuilder<TodoModel> builder)
		{
			builder.ToTable("Todo");

			builder.HasKey(x => x.Id);

			builder.Property(d=>d.Description)
				.IsRequired()
				.HasMaxLength(128);
	
		}
	}
}
