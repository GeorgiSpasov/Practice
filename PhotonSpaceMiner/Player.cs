using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotonSpaceMiner
{
    public enum PlayerState
    {
        Default,
        Shield,
        Speed,
        Dead
    }

    public enum WeaponChoice
    {
        Single,
        Double,
        Bombs,
        Torpedo,
        Spread
    }

    public class Player
    {
        private string skin;
        private PlayerState state;
        private WeaponChoice weapon;
        private ConsoleColor color;
        private Position playerPosition;

        private int lives;
        private int health;
        private int score;
        private int booletsLeft;

        //private bool shielded; //Collision with states

        private string[] stateSkins = {
            "<^>",    //default <^> shoots ^
            "(<^>)",  //shielded (<^>)
            "/^\\",   //speed mode /^\ 
            ">x<"     //dead >x<
        };

        private string[] weaponSkins =
        {
            "\'",//extra single weapons '<^>' shoots '
            "\"",//extra double weapons "<^>" shoots "
            "*",  //extra bombs *<^>* shoots * x X
            "!",  //extra torpedoes !<^>! shoots !
            "|" //spread weapons |<^>| shoots \ /
        };

        public Player() : this(PlayerState.Default, WeaponChoice.Torpedo, ConsoleColor.Cyan, new Position((Console.WindowWidth - 3 /*skin.Length*/) / 2, Console.WindowHeight - 1), 3, 100, 0, 1000)
        {

        }

        public Player(PlayerState state, WeaponChoice weapon, ConsoleColor color, Position playerPosition, int lives, int health, int score, int booletsLeft)
        {
            this.State = state;
            this.Weapon = weapon;
            this.Color = color;
            this.PlayerPosition = playerPosition;

            this.Lives = lives;
            this.Health = health;
            this.Score = score;
            this.booletsLeft = booletsLeft;
        }


        public string Skin
        {
            get
            {
                return this.skin;
            }
            private set //Set by State, Wepons and Shielded
            {
                this.skin = value;
            }
        }

        public PlayerState State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.Skin = stateSkins[(int)value];
                this.state = value;
            }
        }

        public WeaponChoice Weapon
        {
            get
            {
                return this.weapon;
            }
            set
            {
                this.Skin = $"{weaponSkins[(int)value]}{this.skin}{weaponSkins[(int)value]}";
                this.weapon = value;
            }
        }

        public ConsoleColor Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        public Position PlayerPosition
        {
            get
            {
                return this.playerPosition;
            }
            set
            {
                this.playerPosition = value;
            }
        }


        public int Lives
        {
            get
            {
                return this.lives;
            }
            set
            {
                this.lives = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
            }
        }

        public int BooletsLeft
        {
            get
            {
                return this.booletsLeft;
            }
            set
            {
                if (value < 1)
                {
                    this.booletsLeft = 0;
                }
                else
                {
                    this.booletsLeft = value;
                }
            }
        }


        public void Move()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    if (this.PlayerPosition.Y - 1 >= 0)
                    {
                        this.playerPosition.Y -= 1; //TODO: Fix property access
                    }
                }
                else if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    if (this.PlayerPosition.Y + 1 < Console.WindowHeight - 1)
                    {
                        this.playerPosition.Y += 1;
                    }
                }

                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (this.PlayerPosition.X - 1 >= 0)
                    {
                        this.playerPosition.X -= 1; //TODO: Fix property access
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (this.PlayerPosition.X + 1 < Console.WindowWidth - 3)
                    {
                        this.playerPosition.X += 1;
                    }
                }
            }
        }

        public override string ToString()
        {
            return this.Skin;
        }
    }
}
