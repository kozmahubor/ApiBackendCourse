using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_course.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasData(
                new Skill {Id = 1, Name = "Fireball", Damage = 30 },
                new Skill {Id = 2, Name = "Fenzy", Damage = 20 },
                new Skill {Id = 3, Name = "Blizzard", Damage = 50 }
            );

            modelBuilder.Entity<User>()
                .Property(u => u.Role).HasDefaultValue("Player");
        }

        public DbSet<Character> Characters => Set<Character>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Weapon> Weapons => Set<Weapon>();
        public DbSet<Skill> Skills => Set<Skill>();
    }
}