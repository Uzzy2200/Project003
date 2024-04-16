using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Project002Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Models
{
    public class Dbcontext : Microsoft.EntityFrameworkCore.DbContext
    {

        // Constructor with DbContextOptions parameter
        public Dbcontext(DbContextOptions<Dbcontext> options) : base(options)
        {
            // DbSet is "a" Table
            // Add DbSet properties here to represent database tables
        }



        public DbSet<Samurai> Samurai { get; set; }
        public DbSet<War> War { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Weapon> Weapon { get; set; }
        public DbSet<Horses> Horses { get; set; }

    }
}