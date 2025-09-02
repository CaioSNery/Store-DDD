using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(u => u.Image)
                .HasColumnName("Image")
                .HasColumnType("VARCHAR")
                .IsRequired(true)
                .HasMaxLength(200);

            // ----- EMAIL -----
            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(x => x.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Email");

                email.OwnsOne(x => x.Verification, verification =>
                {
                    verification.Property(x => x.Code)
                        .IsRequired()
                        .HasColumnName("EmailVerificationCode");

                    verification.Property(x => x.VerifiedAt)
                        .IsRequired(false)
                        .HasColumnName("EmailVerificationVerifiedAt");

                    verification.Property(x => x.ExpiresAt)
                        .IsRequired(false)
                        .HasColumnName("EmailVerificationExpiresAt");

                    verification.Ignore(x => x.IsActive);
                });
            });

            // ----- PASSWORD -----
            builder.OwnsOne(u => u.Password, password =>
            {
                password.Property(x => x.Hash)
                    .IsRequired()
                    .HasColumnName("PasswordHash");

                password.Property(x => x.ResetCode)

                    .HasColumnName("PasswordResetCode");
            });

            //Relacionamento Roles x Users
            builder.HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRoles",
                    j => j
                        .HasOne<Role>()
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }

}