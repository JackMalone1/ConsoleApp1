using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Hero
    {
        int x;
        int y;

        public int XPos { get => x; set => x = value; }
        public int YPos { get => y; set => y = value; }

        public TileEnum North;
        public TileEnum South;
        public TileEnum East;
        public TileEnum West;

        public Hero()
        {
            North = TileEnum.Empty;
            South = TileEnum.Empty;
            East = TileEnum.Empty;
            West = TileEnum.Empty;
        }
    }
}
