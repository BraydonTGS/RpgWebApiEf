using System;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationships.Data
{
    public class DataContext : DbContext
    {
        // Add the DataBase Sets //
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


    }
}

