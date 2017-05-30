using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krestik_Nolik
{
    public class Player
    {
        public string name { get; set; }
        public string symb { get; set; }
        public Player(string name, string symb)
        {
            this.name = name;
            this.symb = symb;
        }
    

    }
}
