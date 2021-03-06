﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reader.Models;

namespace Reader.Data
{
    public class Context : DbContext
    {
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Reader.db");

#if DEBUG
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feed>().ToTable("Feed")
                .HasAlternateKey(f => f.Uri);
            modelBuilder.Entity<Item>().ToTable("Item")
                .HasAlternateKey(i => i.Uri);
        }
    }
}
