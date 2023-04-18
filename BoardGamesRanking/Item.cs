using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesRanking
{
    public class Item
    {
        public Item(string name, string publisher)
        {
            Name = name;
            Publisher = publisher;
        }
        public virtual string Name { get; set; }
        public virtual string Publisher { get; set; }

    }
}
