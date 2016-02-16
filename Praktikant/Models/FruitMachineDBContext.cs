using System;
using System.Data.Entity;

namespace FruitMachine.Models
{
	public class FruitMachineDbContext : DbContext, IDbHandler
	{
		public DbSet<Fruit> Fruits { get; set; }
	}
}
