using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField] GameObject droppings;
    [SerializeField] private int dropCount = 5;
    [SerializeField] private float spread = 0.7f;
    
    public override void Hit()
    {
        while (dropCount > 0)
        {
            dropCount--;
            Vector3 position = transform.position;
            position.x += spread * Random.value - spread / 2;
            position.y += spread * Random.value - spread / 2;
            GameObject go = Instantiate(droppings);
            go.transform.position = position;
            go.SetActive(true);
        }
        gameObject.SetActive(false);
        //droppings.SetActive(true);
        //Destroy(gameObject);
    }
}
