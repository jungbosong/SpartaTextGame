using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta
{
    public interface IItem
    {
        public void Init(string name, string explanation, int effect, bool purchased, int price);
    }

    public interface IEquipable : IItem
    {
        public void Equip();
    }

    public interface IAttackable
    {
        public int Attack();
    }

    public interface IDefensible
    {
        public int Defense();
    }

    public interface IPurchasable
    {
        public void Purchase();
    }

    public enum ItemType
    {
        NONE,
        AttackItem,
        DefensiveItem,
    }

    public class Item: IItem, IEquipable, IPurchasable
    {
        public string name;
        public string explanation;
        public bool equipped = false;
        public bool purchased;
        public int effect;
        public int price;
        public int type = (int)ItemType.NONE; // 공격 아이템

        public virtual void Init(string name, string explanation, int effect, bool purchased, int price = 0)
        {
            this.name = name;
            this.explanation = explanation;
            this.effect = effect;
            this.purchased = purchased;
            if(purchased == false)
            {
                this.price = price;
            }
        }

        public void Equip()
        {
            equipped = !equipped;
        }

        public void Purchase()
        {
            purchased = !purchased;
        }
    }
}
