using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProcurementDepartament.Models.Entities;

namespace ProcurementDepartament.Data
{
    public class ProcurementDepartamentContext : DbContext
    {
        public ProcurementDepartamentContext (DbContextOptions<ProcurementDepartamentContext> options)
            : base(options)
        {
        }

        public DbSet<Vendor> Vendors { get; set; } = default!;
        public DbSet<User> Users { get; set; }
        public DbSet<AssamblyPart> AssamblyParts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
