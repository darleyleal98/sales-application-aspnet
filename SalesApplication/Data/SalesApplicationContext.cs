using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesApplication.Models.Entities;

namespace SalesApplication.Data
{
    public class SalesApplicationContext : DbContext
    {
        public SalesApplicationContext (DbContextOptions<SalesApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<SalesApplication.Models.Entities.Departament> Departament { get; set; } = default!;
    }
}
