using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ChestInteract : Interactable
{
    [SerializeField] GameObject closed;
    [SerializeField] bool opened;
    public override void Interact(PlayerCharacter character)
    {
        if (!opened)
        {
            opened = true;
            //closed.SetActive(false);
        }
    }
}
