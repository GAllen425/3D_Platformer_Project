using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemManager : MonoBehaviour
{
    public Dictionary<string,int> itemDictionary;
    public UnityEvent invokeMethod;

    void Start()
    {
        itemDictionary = new Dictionary<string, int>();

        invokeMethod.Invoke();
    }

    void Update()
    {
    }

    public void AddItem(string name)
    {
        int currentCount = 0;
        itemDictionary.TryGetValue(name, out currentCount); 
        itemDictionary[name] = currentCount + 1;
    }

    public void RemoveItem(string name)
    {    
        int currentCount = 0;
        itemDictionary.TryGetValue(name, out currentCount); 
        itemDictionary[name] = currentCount - 1; 
    }
}
