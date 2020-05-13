using System;
using System.Threading;
using System.Threading.Tasks;
using DDDCartAppDomain;
using EventFlow;
using EventFlow.Extensions;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using EventFlow.DependencyInjection.Extensions;

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

            await commandBus.PublishAsync(
                new AddProductCommand(CartId.NewCartId(), new ProductId(Guid.Empty)), 
                CancellationToken.None);
        }
    }
}