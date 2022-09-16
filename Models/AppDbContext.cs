﻿using Microsoft.EntityFrameworkCore;

namespace ReactNet.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            /*modelBuilder.Entity<ProductImageModel>().HasKey(table => new {
                table.ProductId,
                table.ImageId
            });*/
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
