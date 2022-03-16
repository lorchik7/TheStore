using System;
using Microsoft.EntityFrameworkCore;
using TheStore.Shared;

namespace TheStore.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Store> Stores { get; set; }
    }
}
