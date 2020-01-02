using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Blobucket
{
    public class BlobEntityContainerServiceCollectionExtensionsTests
    {
        [Fact]
        public void CanResolveContainerFromServiceProvider()
        {
            var services = new ServiceCollection()
                            .AddBlobEntityContainerFactory(c => c.ConnectionString = "UseDevelopmentStorage=true;")
                            .AddBlobEntityContainer<string>(c => c.UseContainerName("people"))
                            .BuildServiceProvider();
            
            services.Invoking(x => services.GetRequiredService<BlobEntityContainer<string>>().Should().NotBeNull()).Should().NotThrow();
        }
    }
}