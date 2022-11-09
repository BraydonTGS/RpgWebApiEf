using System;
using EFCoreRelationships.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationships.Data
{
    public class DataContext : DbContext
    {
        // Add the DataBase Sets //
        public DbSet<User> Users { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


    }
}

