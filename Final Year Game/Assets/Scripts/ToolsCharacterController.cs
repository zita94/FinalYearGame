using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector2 = UnityEngine.Vector2;

public class ToolsCharacterController : MonoBehaviour
{
    private PlayerMovement _character;
    private Rigidbody2D _rigidbody;
    private float _offsetDistance = 0.5f;
    private float _sizeOfInteractableArea = 0.2f;

    private void Awake()
    {
        _character = GetComponent<PlayerMovement>();
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