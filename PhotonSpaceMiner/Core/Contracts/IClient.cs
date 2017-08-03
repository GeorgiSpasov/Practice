using PhotonSpaceMiner.Model;
using System.Net.Sockets;

namespace PhotonSpaceMiner.Core.Contracts
{
    public interface IClient
    {
        TcpClient Client { get; }

        void ConnectClient();

        void SendData(string output);

        string ReadServerData();
    }
}
