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
    }

    internal class Tile
    {
        TileEnum tileType;

        public TileEnum TileType { get => tileType; set => tileType = value; }

        public Tile(TileEnum tileEnum = TileEnum.Empty)
        {
            tileType = tileEnum;
        }
    }
}
