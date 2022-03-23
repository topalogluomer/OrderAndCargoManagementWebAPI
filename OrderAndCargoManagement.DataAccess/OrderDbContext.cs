using Microsoft.EntityFrameworkCore;
using OrderAndCargoManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndCargoManagement.DataAccess
{
    public class OrderDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(local); Database=CargoOrderDb;uid=sa;pwd=123456;");
        }
        public DbSet<ArasCargo> arasCargos { get; set; }
        public DbSet<YurticiCargo> yurticiCargos { get; set; }
    }
}
