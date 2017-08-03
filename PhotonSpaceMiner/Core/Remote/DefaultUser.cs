using PhotonSpaceMiner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotonSpaceMiner.Core.Remote
{
    public class DefaultUser : User
    {

        private Player savedGame;

        public DefaultUser(string userName, string password, Player savedGame = null) : base(userName, password)
        {
            this.SavedGame = savedGame;
        }

        public Player SavedGame
        {
            get
            {
                return this.savedGame;
            }
            set
            {
                if (value == null)
                {
                    this.savedGame = new Player();
                }
                else
                {
                    this.savedGame = value;
                }
            }
        }
    }
}
