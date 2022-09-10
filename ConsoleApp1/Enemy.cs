using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Enemy
    {
        int x;
        int y;

        public int XPos { get => x; set => x = value; }
        public int YPos { get => y; set => y = value; }

        public Dictionary<Direction, TileEnum> Vision = new Dictionary<Direction, TileEnum>();

        public Enemy()
        {
            Vision.Add(Direction.North, TileEnum.Empty);
            Vision.Add(Direction.South, TileEnum.Empty);
            Vision.Add(Direction.East, TileEnum.Empty);
            Vision.Add(Direction.West, TileEnum.Empty);
        }
    }
}
