using System;
using System.Collections.Generic;

namespace PhotonSpaceMiner.Core.Contracts
{
    public interface IGameDB
    {
        Dictionary<Tuple<string, string>, Player> Users { get; }
    }
}
