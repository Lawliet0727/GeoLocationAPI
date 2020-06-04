using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GeoLocationAPI.Models
{ 
    public class GeoDbContext : DbContext
    {
        public DbSet<GeoLocation> Geos { get; set; }

        public GeoDbContext(DbContextOptions<GeoDbContext> options)
            : base(options)
        { }
    }
}
