using EncoraCodingExercise.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EncoraCodingExercise.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        public DbSet<Properties> Properties { get; set; }
        public DbSet<User> AuthUser { get; set; }


    }
}
