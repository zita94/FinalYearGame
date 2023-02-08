using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private Transform _player;

    [SerializeField] private float _speed = 5f;

    [SerializeField] private float _pickupDistance = 1f;

    [SerializeField] private float _ttl = 10f;

    public Item item;
    public int count = 1;
    private void Awake()
    {
        _player = GameManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        _ttl -= Time.deltaTime;
        if (_ttl < 0) { Destroy(gameObject); }

        float distance = Vector3.Distance(transform.position, _player.position);
        if (distance > _pickupDistance) { return; }

        transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);

        if (distance < 0.1f)
        {
            if (GameManager.instance.inventory != null)
            {
                GameManager.instance.inventory.Add(item, count);
            }
            else
            {
                Debug.LogWarning("No inventory container attached to the game manager");
            }

            if (Inventory.itemPickedUp)
            {
                Destroy(gameObject);
            }
        }
    }
}