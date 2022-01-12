using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyAirbnb.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAirbnb.Models
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            this.SeedRoles(builder);
            this.SeedUsers(builder);
            this.SeedUserRoles(builder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole<int>>().HasData(RolesUtils.All);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            string email = "admin@gmail.com";
            AppUser user = new AppUser()
            {
                Id = 1,
                UserName = email,
                Email = email,
                NormalizedUserName = email.ToUpper(),
                NormalizedEmail = email.ToUpper(),
                LockoutEnabled = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin123#");

            builder.Entity<AppUser>().HasData(user);
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>() { RoleId = 1, UserId = 1 }
            );
        }
    }
}
