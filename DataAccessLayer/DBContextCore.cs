using DataAccessLayer.EFModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccessLayer
{
    public class DBContextCore : DbContext
    {
        private string _connectionString = "Server=DESKTOP-PQS42G3\\SQLEXPRESS;DATABASE=Practico3;Trusted_Connection=True;TrustServerCertificate=True";

        public DBContextCore()
        { }

        public DBContextCore(DbContextOptions<DBContextCore> options)
        : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Personas> Personas { get; set; }
    }
}
