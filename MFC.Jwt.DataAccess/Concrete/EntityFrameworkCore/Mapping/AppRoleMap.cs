using MFC.Jwt.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MFC.Jwt.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AppRoleMap:IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(I=>I.Id);
            builder.Property(I=>I.Id).UseIdentityColumn();

            builder.Property(I=>I.Name).HasMaxLength(100).IsRequired();
           

            builder
                .HasMany(I => I.AppUserRoles)
                .WithOne(I => I.AppRole)
                .HasForeignKey(I=>I.AppRoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
