using System.Data.Entity.ModelConfiguration;
using ToDoList.Entity;

namespace ToDoList.Data.Configuration
{
    internal class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            // Description schema specifications
            Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
