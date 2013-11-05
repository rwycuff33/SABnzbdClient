using FakeItEasy;
using SABnzbdClient.Interface;
using Xunit;

namespace SABnzbdClient.Tests
{
    public class ClientTests
    {
        [Fact]
        public void Should_Initialize_Client()
        {
            //Given
            var config = new ClientConfiguration();

            //When
            var client = new Client(config);

            //Then
            Assert.NotNull(client.ClientConfiguration);
            Assert.Equal(config, client.ClientConfiguration);
        }

        [Fact]
        public void Should_Provide_Default_Server_Repository()
        {
            //Given

            //When
            var client = new Client(null);

            //Then
            Assert.NotNull(client.ServerRepository);
        }

        [Fact]
        public void Should_Allow_Server_Repository_Override()
        {
            //Given
            var serverRepository = A.Fake<IServerRepository>();

            //When
            var client = new Client(null /* ClientConfigufation */, serverRepository);

            //Then
            Assert.NotNull(client.ServerRepository);
            Assert.Equal(serverRepository, client.ServerRepository);
        }
    }
}