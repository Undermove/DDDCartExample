using EventFlow.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DDDCartAppTests
{
	public class CartContext : DbContext
	{
		public CartContext(DbContextOptions options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.AddEventFlowEvents()
				.AddEventFlowSnapshots();
		}
	}
}