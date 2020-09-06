using System.Data.Entity.ModelConfiguration;

namespace PluralSightBook.Data.Models.Mapping
{
    public class FriendMap : EntityTypeConfiguration<Friend>
    {
        public FriendMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.EmailAddress)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Friends");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            this.Property(t => t.UserId).HasColumnName("UserId");

            // Relationships
            this.HasRequired(t => t.aspnet_Membership)
                .WithMany(t => t.Friends)
                .HasForeignKey(d => d.UserId);
        }
    }
}
