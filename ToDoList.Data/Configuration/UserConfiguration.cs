using System.Data.Entity.ModelConfiguration;
using ToDoList.Entity;

namespace ToDoList.Data.Configuration
{
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            // Username schema specifications
            Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(255);

            // Password schema specifications
            Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
