using EventFlow.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DDDCartAppTests
{
	public class MySqlCartContextProvider: IDbContextProvider<CartContext>
	{
		private DbContextOptions<CartContext> _options;
		public MySqlCartContextProvider()
		{
			_options = new DbContextOptionsBuilder<CartContext>()
				.UseMySql("Server=localhost; Database=carts; User=root")
				.Options;
		}
		public CartContext CreateContext()
		{
			var context = new CartContext(_options);
			context.Database.EnsureCreated();
			return context;
		}
	}
}