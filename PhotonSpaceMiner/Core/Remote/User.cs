using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhotonSpaceMiner.Core.Contracts;

namespace PhotonSpaceMiner.Core.Remote
{
    public class User : IUser
    {
        private string userName;
        private string password;

        public User(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        // Add validations =============================
        public string UserName
        {
            get
            {
                return this.userName;
            }
            private set
            {
                this.userName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }
    }
}
