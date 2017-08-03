using System;
using System.Collections.Generic;

using PhotonSpaceMiner.Model;

namespace PhotonSpaceMiner.Core.Contracts
{
    public interface IGameDB
    {
        Dictionary<Tuple<string, string>, Player> Users { get; }
    }
}
