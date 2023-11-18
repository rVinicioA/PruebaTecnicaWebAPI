using System.Collections.Generic;
using System.Numerics;
using PruebaTecnicaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnicaAPI.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<TodoTask> TodoTask { get; set; }
  
    }
}
