using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShowroom.Models;

namespace CarShowroom
{
    public class CarsDbContext : DbContext
    {
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Showroom> Showrooms { get; set; }

        public CarsDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-M3US80J;Initial Catalog=CarShowroom;Integrated Security=True;Pooling=False;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Showroom>(entity =>
            {
                entity.HasKey(x => x.ShowroomId);

                entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnName("ShowroomName");

                entity.Property(x => x.Phone)
                .HasMaxLength(16)
                .HasColumnName("ShowroomPhone");

                entity.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnName("ShowroomAddress");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasIndex(x => x.ShowId, "IX_Cars_ShowId");

                entity.Property(x => x.Make)
                .IsRequired()
                .HasMaxLength(24);

                entity.Property(x => x.Model)
                .IsRequired()
                .HasMaxLength(24);

                entity.Property(x => x.ModelYear)
                .IsRequired()
                .HasMaxLength(4);

                entity.Property(x => x.EngineCapacity)
                .HasMaxLength(5);

                entity.Property(x => x.Price)
                .HasMaxLength(16);

                entity.HasOne(x => x.ShowroomInfo).WithMany(y => y.Cars).HasForeignKey(x => x.ShowId);
            });
        }
    }
}
