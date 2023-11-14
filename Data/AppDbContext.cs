using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using design_pattern.Models;
using design_pattern.Models.Branches;
using design_pattern.Models.Meal;
using design_pattern.Models.Menu;
using design_pattern.Models.Payments;
using design_pattern.Models.Tables;
using design_pattern.Models.Workers;
using Microsoft.EntityFrameworkCore;

namespace design_pattern.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<MenuSection> MenuSections { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuCmp> MenuCmp { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Cachier> Cachiers { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<MealItem> MealItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentRecord> Payments { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Worker>().ToTable("Workers");
            builder.Entity<Manager>().ToTable("Managers");
            builder.Entity<Cachier>().ToTable("Cachiers");
            builder.Entity<Chef>().ToTable("Chefs");
            builder.Entity<Receptionist>().ToTable("Receptionists");
            builder.Entity<Waiter>().ToTable("Waiters");
            builder.Entity<MenuCmp>().ToTable("menu_components");
            builder.Entity<MenuSection>().ToTable("menu_sections");
            builder.Entity<MenuItem>().ToTable("menu_items");


            // builder.Entity<Table>().HasMany<Reservation>().WithOne(x=>x.Table).HasForeignKey(x=>x.TableNumber);
            // builder.Entity<Reservation>().HasOne<Table>().WithMany(x=>x.Reservations);

            builder.Entity<Branch>().HasMany<Table>().WithOne(x=>x.Branch).HasForeignKey(x=>x.BranchName);
            builder.Entity<Branch>().HasMany<Worker>().WithOne(x=>x.Branch).HasForeignKey(x=>x.BranchName);
            builder.Entity<Manager>().HasOne<Branch>().WithOne(x=>x.Manager).HasForeignKey<Branch>(x=>x.ManagerId);

            builder.Entity<MenuItem>().HasMany<MealItem>().WithOne(x=>x.Item).HasForeignKey(x=>x.MenuItemId);
            builder.Entity<Order>().HasMany<MealItem>(x=>x.MealItems).WithOne(x=>x.Order);
            builder.Entity<MealItem>().HasOne<Order>(x=>x.Order).WithMany(x=>x.MealItems);
            
            builder.Entity<Order>().HasOne<Reservation>(x=>x.Reservation).WithOne(x=>x.Order).HasForeignKey<Order>(x=>x.ReservationId);

            Branch b1,b2,b3;
            b1 = new Branch(){Name="Italy Branch", ManagerId=1};
            b2 = new Branch(){Name="Egypt Branch", ManagerId=2};
            b3 = new Branch(){Name="Japan Branch", ManagerId=3};
            builder.Entity<Branch>().HasData(b1);
            builder.Entity<Branch>().HasData(b2);
            builder.Entity<Branch>().HasData(b3);
            Manager m1,m2,m3;
            m1 = new Manager(){BranchName="Italy Branch", Id=1, salary=3000, workerName="Alberto"};
            m2 = new Manager(){BranchName="Egypt Branch", Id=2, salary=2500, workerName="Ali"};
            m3 = new Manager(){BranchName="Japan Branch", Id=3, salary=10000, workerName="Tanaka"};
            builder.Entity<Manager>().HasData(m1);
            builder.Entity<Manager>().HasData(m2);
            builder.Entity<Manager>().HasData(m3);
        }
    }
}