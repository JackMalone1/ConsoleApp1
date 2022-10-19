using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum TileEnum 
    {
        Hero,
        Enemy,
        Empty,
        Obstacle,
        Swamp,
        Gold,
        Weapon,
    }

    internal abstract class Tile
    {
        protected int x;
        protected int y;

        protected TileEnum tileType;

        public TileEnum TileType { get => tileType; set => tileType = value; }

        public int X { get => x; set => x = value; }

        protected int Y { get => y; set => y = value; }

        public Tile(TileEnum tileEnum = TileEnum.Empty, int x = 0, int y = 0)
        {
            tileType = tileEnum;
            this.x = x;
            this.y = y;
        }
    }
}
