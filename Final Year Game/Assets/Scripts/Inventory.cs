using System;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public static bool itemPickedUp;
    public const int MAXINVENTORY = 99;

    public void Add(Item item, int count = 1)
    {
        if (item.stackable)
        {
            ItemSlot itemSlot = slots.Find(x => x.item == item && x.count < MAXINVENTORY);
            {
                if (itemSlot != null && itemSlot.count < MAXINVENTORY)
                {
                    int temp = count;
                    for (int i = 0; i <count; i++) {
                        
                        if (itemSlot.count < MAXINVENTORY)
                        {
                            itemSlot.count += count;
                            temp--;
                        }
                        else
                        {
                            itemSlot = slots.Find(x => x.item == null);
                            if (itemSlot == null) return;
                            itemSlot.item = item;
                            itemSlot.count = temp;
                        }

                    }
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

        itemPickedUp = true;
    }
}