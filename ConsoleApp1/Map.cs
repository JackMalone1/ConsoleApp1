using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Map
    {
        private Tile[,] tileMap;
        private Hero player;
        private Enemy[] enemies;
        private int mapWidth;
        private int mapHeight;
        private Random random;
        private int currentEnemy = 0;

        public Tile[,] TileMap { get; private set; }

        public Map(int minimumHeight, int maximumHeight, int minimumWidth, int maximumWidth, int numberOfEnemies)
        {
            random = new Random(Guid.NewGuid().GetHashCode());//make sure to seed random
            mapWidth = random.Next(minimumWidth, maximumWidth);
            mapHeight = random.Next(minimumHeight, maximumHeight);
            enemies = new Enemy[numberOfEnemies];
            tileMap = new Tile[mapWidth, mapHeight];
            player = new Hero();//ensure that player is not null leaving the constructor

            for(int i = 0; i < mapHeight; i++)
            {
                for(int j = 0; j < mapWidth; j++)
                {
                    if(IsAtEdgeOfMap(j, i))
                    {
                        tileMap[i, j].TileType = TileEnum.Obstacle; 
                    }
                }
            }

            var tile = Create(TileEnum.Hero);
            tileMap[player.XPos, player.YPos] = tile;

            for(int i = 0; i < numberOfEnemies; i++)
            {
                var enemyTile = Create(TileEnum.Enemy);
                tileMap[enemies[i].XPos, enemies[i].YPos] = enemyTile;
            }
            UpdateVision();
        }

        private bool IsAtEdgeOfMap(int x, int y)
        {
            return y == 0 || y == mapHeight - 1 || x == 0 || x == mapWidth - 1;
        }

        private Tile Create(TileEnum type)
        { 
            Tile tile = new(type);
            int xPos;
            int yPos;
            do
            {
                xPos = random.Next(mapWidth, mapHeight);
                yPos = random.Next(mapHeight, mapWidth);
            } while (IsValidIndexToPlaceAt(xPos, yPos));

            switch (type)
            { 
                case TileEnum.Enemy:
                    Enemy enemy = new Enemy();
                    enemy.XPos = xPos;
                    enemy.YPos = yPos;
                    enemies[currentEnemy] = enemy;
                    currentEnemy++;
                    break;
                case TileEnum.Hero:
                    player.XPos = xPos;
                    player.YPos = yPos;
                    break;
            }
            return tile;
        }

        private bool IsValidIndexToPlaceAt(int x, int y)
        {
            //make sure you're trying to place inside the map and there isn't already something at the index that you're going to
            return IsValidIndex(x, y) && tileMap[x, y].TileType == TileEnum.Empty;
        }

        private bool IsValidIndex(int x, int y)
        {
            return x >= 0 && x < mapWidth && y >= 0 && y < mapHeight;
        }

        public void UpdateVision()
        {
            if (player != null)
            {
                player.Vision[Direction.North] = IsValidIndex(player.XPos - 1, player.YPos) ? tileMap[player.XPos - 1, player.YPos].TileType : TileEnum.Empty;
                player.Vision[Direction.South] = IsValidIndex(player.XPos + 1, player.YPos) ? tileMap[player.XPos + 1, player.YPos].TileType : TileEnum.Empty;
                player.Vision[Direction.East] = IsValidIndex(player.XPos, player.YPos + 1) ? tileMap[player.XPos, player.YPos + 1].TileType : TileEnum.Empty;
                player.Vision[Direction.West] = IsValidIndex(player.XPos, player.YPos - 1) ? tileMap[player.XPos, player.YPos - 1].TileType : TileEnum.Empty;
            }

            if(enemies != null)
            {
                foreach(var enemy in enemies)
                {
                    enemy.Vision[Direction.North] = IsValidIndex(enemy.XPos - 1, enemy.YPos) ? tileMap[enemy.XPos - 1, enemy.YPos].TileType : TileEnum.Empty;
                    enemy.Vision[Direction.South] = IsValidIndex(enemy.XPos + 1, enemy.YPos) ? tileMap[enemy.XPos + 1, enemy.YPos].TileType : TileEnum.Empty;
                    enemy.Vision[Direction.East] = IsValidIndex(enemy.XPos, enemy.YPos + 1) ? tileMap[enemy.XPos, enemy.YPos + 1].TileType : TileEnum.Empty;
                    enemy.Vision[Direction.West] = IsValidIndex(enemy.XPos, enemy.YPos - 1) ? tileMap[enemy.XPos, enemy.YPos - 1].TileType : TileEnum.Empty;
                }
            }
        }
    }
}
