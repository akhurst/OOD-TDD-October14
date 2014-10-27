using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODTDD
{
    public class Player
    {
        public Player(string token)
        {
            Token = token;
        }

        public string Token { get; private set; }
    }
}
