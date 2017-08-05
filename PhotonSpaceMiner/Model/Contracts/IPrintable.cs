using System;

namespace PhotonSpaceMiner.Model.Contracts
{
    public interface IPrintable
    {
        Position PlayerPosition { get; }

        ConsoleColor Color { get; }
    }
}
