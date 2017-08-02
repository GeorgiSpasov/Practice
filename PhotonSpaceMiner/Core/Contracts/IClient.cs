namespace PhotonSpaceMiner.Core.Contracts
{
    public interface IClient
    {
        void ConnectClient();

        void SendData(string output);

        void ReadServerData();
    }
}
