using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore
{
    // Управление соединением с базой данных
    public class Northwind : DbContext
    {
        // Свойства, сопоставляемые с таблицами в базе данных
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Для Microsoft SQL Server
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True");
            // Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Пример использования Fluent API вместо атрибутов для ограничения имени категории 40 символами
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(40);
        }
    }
}
