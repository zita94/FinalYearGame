using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Inventory;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _text;

    private int _slotIndex;

    public void SetIndex(int index)
    {
        _slotIndex = index;
    }

    public void Set(ItemSlot itemSlot)
    {
        _icon.gameObject.SetActive(true);
        _icon.sprite = itemSlot.item.icon;

        if (itemSlot.item.stackable == true)
        {
            _text.gameObject.SetActive(true);
            _text.text = itemSlot.count.ToString();
        }
        else
        {
            _text.gameObject.SetActive(false);
        }
    }

    public void Clean()
    {
        _icon.sprite = null;
        _icon.gameObject.SetActive(false);
        _text.gameObject.SetActive(false);
    }
}