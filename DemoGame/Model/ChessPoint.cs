using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGame.Model
{
    public class ChessPoint
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public bool TurnOnStatus { get; set; }

        public int Key => int.Parse(this.Row.ToString() + this.Column.ToString());
    }
}
