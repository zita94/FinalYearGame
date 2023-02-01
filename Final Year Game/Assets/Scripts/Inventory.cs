using System;
using System.Collections.Generic;
using UnityEngine;

    [Serializable]

    public class ItemSlot
    {
        public Item item;
        public int count;
    }

    [CreateAssetMenu(menuName = "Data/Inventory")]
    public class Inventory : ScriptableObject
    {
        public List<ItemSlot> slots;

        public void Add(Item item, int count = 1)
        {
            if (item.stackable)
            {
                ItemSlot itemSlot = slots.Find(x => x.item == item);
                {
                    if (itemSlot != null)
                    {
                        itemSlot.count += count;
                    }
                    else
                    {
                        itemSlot = slots.Find(x => x.item == null);
                        if (itemSlot == null) return;
                        itemSlot.item = item;
                        itemSlot.count = count;
                    }
                }
            }
            else
            {
                //add non-stackable items to inventory;
                ItemSlot itemSlot = slots.Find(x => x.item == null);
                if (itemSlot != null)
                {
                    itemSlot.item = item;
                }
            }
        }
    }