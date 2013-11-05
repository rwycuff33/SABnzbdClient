using FakeItEasy;
using SABnzbdClient.Interface;
using Xunit;

namespace SABnzbdClient.Tests
{
    public class VersionTests
    {

        private readonly IServerRepository _serverRepository;

        public VersionTests()
        {
            _serverRepository = A.Fake<IServerRepository>();
        }

        [Fact]
        public void Should_Call_Repository_Get_Version()
        {
            //Given
            var client = new Client(null, _serverRepository);
            A.CallTo(() => _serverRepository.GetVersion()).Returns(@"{""version"": ""0.6.15""}");

            //When
            client.Version();

            //Then
            A.CallTo(() => _serverRepository.GetVersion()).MustHaveHappened();
        }

        [Fact]
        public void Should_Parse_Version_Information_From_Server()
        {
            //Given
            var client = new Client(null, _serverRepository);
            A.CallTo(() => _serverRepository.GetVersion()).Returns(@"{""version"": ""1.6.15.2""}");

            //When
            var result = client.Version();

            //Then
            Assert.NotNull(result);
            Assert.Equal("1.6.15.2", result.Version);
            Assert.Equal(1, result.Major);
            Assert.Equal(6, result.Minor);
            Assert.Equal(15, result.Revision);
            Assert.Equal(2, result.Build);
        }
    }
}