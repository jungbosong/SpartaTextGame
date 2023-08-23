using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sparta
{
    public class Inventory
    {
        private static Inventory _instance = null;
        public static Inventory Instance()
        {
            if (_instance == null)
            {
                _instance = new Inventory();
            }
            return _instance;
        }
        Store store = Store.Instance();
        public List<Item> items = new List<Item>();
        //public List<AttackItem> attackItems = new List<AttackItem>();
        //public List<DefensiveItem> defensiveItems = new List<DefensiveItem>();

        public void SetInventoryItem()
        {
            foreach(Item item in store.items)
            {
                if(item.purchased)
                {
                    items.Add(item);
                }
            }
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void DeleteItem(int idx)
        {
            items.RemoveAt(idx);
        }
    }
}