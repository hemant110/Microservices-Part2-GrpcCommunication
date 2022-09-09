using Microsoft.EntityFrameworkCore;
using QCService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QCService.DBContexts
{
    public class QualityCheckDbContext :DbContext
    {
        public QualityCheckDbContext(DbContextOptions<QualityCheckDbContext> options): base(options)
        {
        }

        public DbSet<QualityCheck> QualityCheck { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
