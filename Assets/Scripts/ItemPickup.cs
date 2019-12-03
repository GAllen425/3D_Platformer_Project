using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemPickup : MonoBehaviour
{
    public ItemManager itemManager;
    void Start()
    {
        itemManager = GameObject.Find("GameManager").GetComponent<ItemManager>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerItems>().AddItem(this.gameObject.tag);
            itemManager.RemoveItem(this.gameObject.tag);
            Destroy(this.gameObject);
        }
    }


}
