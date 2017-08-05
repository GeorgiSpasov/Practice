using System.Net.Sockets;

using PhotonSpaceMiner.Model;

namespace PhotonSpaceMiner.Core.Contracts
{
    public interface IClient
    {
        TcpClient Client { get; }

        Player ClientPlayer { get; set; }

        void ConnectClient();

        void SendData(string output);

        string ReadServerData();
    }
}
