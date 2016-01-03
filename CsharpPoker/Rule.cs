using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpPoker
{
    public class Rule
    {
        public Rule(string name, Func<bool> predicate, int strength)
        {
            this.Name = name;
            this.Predicate = predicate;
            this.Strength = strength;
        }

        public string Name { get; private set; }

        public Func<bool> Predicate { get; private set; }

        public int Strength { get; private set; }

    }
}
