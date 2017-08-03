using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotonSpaceMiner.Model.Contracts
{
    public interface IPrintable
    {
        Position PlayerPosition { get; }

        ConsoleColor Color { get; }
    }
}
