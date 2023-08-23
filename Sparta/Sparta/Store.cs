using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta
{
    public class Store
    {
        private static Store _instance = null;
        public static Store Instance()
        {
            if (_instance == null)
            {
                _instance = new Store();
            }
            return _instance;
        }
        public List<Item> items = new List<Item>();
        public List<AttackItem> attackItems = new List<AttackItem>();
        public List<DefensiveItem> defensiveItems = new List<DefensiveItem>();
        public int itemCount;

        public void Init()
        {
            defensiveItems.Clear();
            AddDefensiveItem("무쇠값옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 9, true, 100);
            AddDefensiveItem("수련자 값옷", "수련에 도움을 주는 갑옷입니다.", 5, false, 1000);
            AddDefensiveItem("스파르타의 값옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 15, false, 3500);

            attackItems.Clear();
            AddAttackItem("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 2, true, 60);
            AddAttackItem("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 5, false, 600);
            AddAttackItem("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, false, 2100);

            itemCount = items.Count;
        }

        public void AddAttackItem(string name, string explanation, int effect, bool purchased, int price)
        {
            AttackItem item = new AttackItem();
            item.Init(name, explanation, effect, purchased, price);
            attackItems.Add(item);
            items.Add(item);
        }

        public void AddDefensiveItem(string name, string explanation, int effect, bool purchased, int price)
        {
            DefensiveItem item = new DefensiveItem();
            item.Init(name, explanation, effect, purchased, price);
            defensiveItems.Add(item);
            items.Add(item);
        }

        public void DeleteItem(int idx)
        {
            items.RemoveAt(idx);
        }

    }
}
