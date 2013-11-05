using SABnzbdClient.Concrete;
using SABnzbdClient.Interface;
using SABnzbdClient.Model;
using ServiceStack.Text;

namespace SABnzbdClient
{
    public class Client
    {
        public ClientConfiguration ClientConfiguration { get; set; }
        public IServerRepository ServerRepository { get; set; }

        public Client(ClientConfiguration clientConfiguration, IServerRepository serverRepository = null)
        {
            ClientConfiguration = clientConfiguration;
            ServerRepository = serverRepository ?? DefaultServerRepository();
        }

        private IServerRepository DefaultServerRepository()
        {
            return new ServerRepository();
        }

        public ServerVersion Version()
        {
            var version = ServerRepository.GetVersion();

            var serverVersion = version.FromJson<ServerVersion>();
            serverVersion.ExtractVersionAttributes();

            return serverVersion;
        }
    }
}