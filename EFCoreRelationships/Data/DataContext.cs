using System;
using EFCoreRelationships.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationships.Data
{
    public class DataContext : DbContext
    {
        // Add the DataBase Sets //
        DbSet<User> Users { get; set; }

        DbSet<Character> Characters { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


    }
}

