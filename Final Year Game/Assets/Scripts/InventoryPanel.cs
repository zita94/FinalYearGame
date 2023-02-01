using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private List<InventoryButton> _buttons;

    private void Update()
    {
        SetIndex();
        Show();
    }

    private void Show()
    {
        for (int i = 0; i < _inventory.slots.Count; i++)
        {
            if (_inventory.slots[i].item == null)
            {
                _buttons[i].Clean();
            }
            else
            {
                _buttons[i].Set(_inventory.slots[i]);
            }
        }
    }

    private void SetIndex()
    {
        for (int i = 0; i < _inventory.slots.Count; i++)
        {
            _buttons[i].SetIndex(i);
        }
    }
}