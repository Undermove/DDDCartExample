using System;
using System.Threading;
using System.Threading.Tasks;
using DDDCartAppDomain;
using EventFlow;
using EventFlow.Extensions;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using EventFlow.DependencyInjection.Extensions;
using EventFlow.Aggregates;

namespace DDDCartAppTests
{
    public class CommandBusTests
    {
        [Test]
        public async Task CommandBusTest()
        {
            var services = new ServiceCollection();
            services.AddTransient<IProductRepository, FakeProductRepository>();

            var resolver = EventFlowOptions.New
                .UseServiceCollection(services)
                .AddEvents(typeof(ProductAddedEvent))
                .AddCommands(typeof(AddProductCommand))
                .AddCommandHandlers(typeof(AddProductCommandHandler))
                .CreateResolver();

            var commandBus = resolver.Resolve<ICommandBus>();
            var aggregateStore = resolver.Resolve<IAggregateStore>();

            CartId cartId = CartId.NewCartId();
            await commandBus.PublishAsync(
                new AddProductCommand(cartId, new ProductId(Guid.Empty)), 
                CancellationToken.None);

            Cart cart = await aggregateStore.LoadAsync<Cart, CartId>(cartId, CancellationToken.None);

            Assert.AreEqual(1, cart.Products.Count);
        }
    }
}