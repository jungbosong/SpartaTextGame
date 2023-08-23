using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta
{
    public class AttackItem: Item, IAttackable
    {
        public override void Init(string name, string explanation, int effect, bool purchased, int price)
        {
            base.Init(name, explanation, effect, purchased, price);
            type = (int)ItemType.AttackItem;
        }
        public int Attack()
        {
            return effect;
        }
    }
}
