﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
//using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sparta
{
    public enum Job
    {
        WARRIOR,
        WIZARD,
        HEALER,
        TANKER,
    }
    public enum PurchaseType
    {
        NoMore,
        Success,
        LackGold,
    }

    public class Player
    {
        private static Player _instance = null;
        public static Player Instance()
        {
            if (_instance == null)
            {
                _instance = new Player();
            }
            
            return _instance;
        }

        public int level = 1;
        public Job job = Job.WARRIOR;
        public int hp = 100;
        public int atk = 10;
        public int def = 5;
        public int increasedAtk = 0;
        public int increasedDef = 0;
        public int gold = 1500;
        Inventory inventory = Inventory.Instance();
        Store store = Store.Instance();
        HashSet<string> equippedAtkItems = new HashSet<string>();
        HashSet<string> equippedDefItems = new HashSet<string>();

        public void UpdateInfo()
        {
            equippedAtkItems.Clear();
            equippedDefItems.Clear();
            atk = 10;
            def = 5;
            increasedAtk = 0;
            increasedDef = 0;
            SetIncreasedAtk();
            SetIncreasedDef();   
        }

        public void SetIncreasedAtk()
        {
            foreach(Item item in inventory.items)
            {
                if (item.equipped)
                {
                    if (item.type == (int)ItemType.AttackItem)
                    {
                        increasedAtk += item.effect;
                        atk += increasedAtk;
                        equippedAtkItems.Add(item.name);
                    }
                }
                else if(equippedAtkItems.Contains(item.name))
                {
                    equippedAtkItems.Remove(item.name);
                    increasedAtk -= item.effect;
                    atk -= increasedAtk;
                }
            }            
        }

        public void SetIncreasedDef()
        {
            foreach (Item item in inventory.items)
            {
                if (item.equipped)
                {
                    if (item.type == (int)ItemType.DefensiveItem)
                    {
                        increasedDef += item.effect;
                        def += increasedDef;
                        equippedDefItems.Add(item.name);
                    }
                }
                else if (equippedAtkItems.Contains(item.name))
                {
                    equippedDefItems.Remove(item.name);
                    increasedDef -= item.effect;
                    def -= increasedDef;
                }
            }
        }

        public void EquipItem(int idx)
        {
            inventory.items[idx-1].Equip();
        }
        public PurchaseType Purchase(int idx)
        {
            if (store.items[idx].purchased)
            {
                return PurchaseType.NoMore;
            }
            else if (gold < store.items[idx].price)
            {
                return PurchaseType.LackGold;
            }
            else
            {
                gold -= store.items[idx].price;
                store.items[idx].purchased = true;
                inventory.AddItem(store.items[idx]);
                return PurchaseType.Success;
            }
        }

        public void Sell(int idx)
        {

        }

        public string JobToString()
        {
            string result = "";
            switch(job)
            {
                case Job.WARRIOR:
                    result = "전사";
                    break;
                case Job.WIZARD:
                    result = "마법사";
                    break;
                case Job.HEALER:
                    result = "힐러";
                    break;
                case Job.TANKER:
                    result = "탱커";
                    break;
            }
            return result;
        }
    }
}