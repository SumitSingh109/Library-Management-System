using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Data
{
    public class CatalogueDBContext : DbContext
    {
        public CatalogueDBContext(DbContextOptions<CatalogueDBContext> options): base(options)
        {

        }

        public DbSet<Catalogue> Catalogue { get; set; }
    }
}
