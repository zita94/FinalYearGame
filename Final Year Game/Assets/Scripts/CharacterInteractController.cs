using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    PlayerMovement characterController;
    private Rigidbody2D rigidbody;
    private float _offsetDistance = 0.5f;
    private float _sizeOfInteractableArea = 0.5f;
    private PlayerCharacter player;

    private void Awake()
    {
        characterController = GetComponent<PlayerMovement>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }
    private void Interact()
    {
        Vector2 position = rigidbody.position + PlayerMovement.moveDirection * _offsetDistance;

        Collider2D[] collider = Physics2D.OverlapCircleAll(position, _sizeOfInteractableArea);

        foreach (Collider2D c in collider)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact(player);
                break;
            }
        }
    }

}
