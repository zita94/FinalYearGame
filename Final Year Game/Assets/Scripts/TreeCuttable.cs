using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField] GameObject _droppings;
    [SerializeField] private EdgeCollider2D _collider;

    private int _dropCount = 5;
    private float _spread = 0.7f;
    private int _cutsNeeded = 2;

    public override void Hit()
    {
        if (_cutsNeeded > 0)
        {
            _cutsNeeded--;
        }
        else
        {
            while (_dropCount > 0)
            {
                _dropCount--;
                Vector3 position = transform.position;
                position.x += _spread * Random.value - _spread / 2;
                position.y += _spread * Random.value - _spread / 2;
                GameObject go = Instantiate(_droppings);
                go.transform.position = position;
                go.SetActive(true);
            }

            gameObject.SetActive(false);
        }
    }
}
