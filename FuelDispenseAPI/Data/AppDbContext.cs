using FuelDispenseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FuelDispenseAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }
        public DbSet<DispenseRecord> DispenseRecords { get; set; }
    }
}
