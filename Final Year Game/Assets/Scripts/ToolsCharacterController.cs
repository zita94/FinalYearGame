using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolsCharacterController : MonoBehaviour
{
    private CharacterController _character;
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _offsetDistance = 1f;
    [SerializeField] float _sizeOfInteractableArea = 1.2f;

    private void Awake()
    {
        _character = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        Vector2 position = _rigidbody.position + PlayerMovement.moveDirection * _offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, _sizeOfInteractableArea);

        foreach (Collider2D collider in colliders)
        {
            ToolHit hit = collider.GetComponent<ToolHit>();
            if (hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }
}