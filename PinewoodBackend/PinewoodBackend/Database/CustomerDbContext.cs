using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace PinewoodBackend.Database
{
    public class CustomerDbContext : DbContext
    {
		public DbSet<Customer> Customers { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=customer;ConnectRetryCount=0");
		}
    }
}
