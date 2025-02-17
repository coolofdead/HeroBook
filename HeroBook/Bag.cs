using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace HeroBook
{
    public class Bag : IEnumerable
    {
        public const int BAG_LIMIT = 8;

        public Dictionary<Item, int> Items = new();

        public Equipement FirstEquipement;
        public Equipement SecondEquipement;

        public void AddItem(Item item, int quantity = 1)
        {
            if (Items.Count == BAG_LIMIT)
            {
                Console.WriteLine($"Tu as atteint la limite de place dans ton sac, tu ne peux pas récuperer {item}");
            }

            Items[item] += quantity;
        }

        public void UseItem(Item item, int quantity = 1)
        {
            Items[item] -= quantity;
        }

        public int GetQuantity(Item item)
        {
            return Items[item];
        }

        public bool HasItem(Item item)
        {
            return Items.Any(i => i.Key.Id == item.Id);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in Items)
            {
                yield return item.Key;
            }
        }
    }
}
