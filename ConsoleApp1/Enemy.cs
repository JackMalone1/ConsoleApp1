using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal abstract class Enemy : Character
    {
        protected Random random;
        public Enemy(int x, int y, char symbol, int damage) : base(x, y, symbol)
        {
            this.damage = damage;
            random = new Random();
        }

        public override Movement ReturnMove(Movement move)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("Enemy at [{0},{1}]({2})", x, y, damage);
        }
    }
}
