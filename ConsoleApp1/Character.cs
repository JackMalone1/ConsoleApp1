using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum Movement
    {
        None,
        Up,
        Down,
        Left,
        Right,
    }

    internal abstract class Character : Tile
    {
        protected int hp;
        protected int maxHp;
        protected int damage;
        protected Tile[] vision;
        public Movement Movement;
        protected char symbol;

        public Character(int x, int y, char symbol) : base(TileEnum.Hero, x, y)
        {
            
        }

        public virtual void Attack(Character target)
        {
            target.hp -= damage;
        }

        public bool IsDead()
        {
            return hp <= 0;
        }

        public virtual bool CheckRange(Character target)
        {
            return DistanceTo(target) <= 1;
        }

        private int DistanceTo(Character target)
        {
            return Math.Abs(x - target.x) + Math.Abs(y - target.y);
        }

        public void Move(Movement move)
        {
            if (move == Movement.Up)
            {
                y--;
            }
            else if (move == Movement.Down)
            {
                y++;
            }
            else if (move == Movement.Left)
            {
                x--;
            }
            else if (move == Movement.Right)
            {
                x++;
            }
        }

        public abstract Movement ReturnMove(Movement move);
        public abstract override string ToString();
    }
}
