using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpPoker
{
    public class Rank
    {
        public Rank(string name, Func<IEnumerable<Card>,bool> eval, int strength)
        {
            this.Name = name;
            this.Eval = eval;
            this.Strength = strength;
        }

        public string Name { get; private set; }

        public Func<IEnumerable<Card>, bool> Eval { get; private set; }

        public int Strength { get; private set; }

    }
}
