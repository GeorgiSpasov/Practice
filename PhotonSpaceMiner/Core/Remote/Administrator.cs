using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotonSpaceMiner.Core.Remote
{
    public class Administrator : User
    {
        public Administrator(string userName, string password) : base(userName, password)
        {
        }
    }
}
