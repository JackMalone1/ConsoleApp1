using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GameEngine
    {
        static readonly char hero = 'H';
        static readonly char swamp = 'S';
        static readonly char creature = 'C';
        static readonly char empty = '.';
        static readonly char obstacle = 'X';

        Dictionary<TileEnum, char> tiles = new Dictionary<TileEnum, char>() { { TileEnum.Hero, hero}, { TileEnum.Swamp, swamp}, { TileEnum.Enemy, creature},
            { TileEnum.Empty , empty}, { TileEnum.Obstacle, obstacle}, };

        Map map;
        public Map Map { get => map; private set => map = value; }

        public override string ToString()
        {
            string resultString = string.Empty;

            var tileMap = map.TileMap;

            for(int i = 0; i < tileMap.GetLength(0); i++)
            {
                for(int j = 0; j < tileMap.GetLength(1); j++)
                {
                    resultString += tiles[tileMap[i, j].TileType];
                }
                resultString += "/n";
            }

            return resultString;
        }

        public GameEngine()
        {
            map = new Map(10, 30, 10, 30, 5);
        }
    }
}
