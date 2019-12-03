using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemManager : MonoBehaviour
{
    public Dictionary<string,int> itemDictionary;
    public UnityEvent invokeMethod;
    public int countAcorn = 0;
    // Start is called before the first frame update
    void Start()
    {
        itemDictionary = new Dictionary<string, int>();

        invokeMethod.Invoke();
    }

    // Update is called once per frame
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

    public void Count(string name)
    {
        countAcorn = itemDictionary[name];
    }
}
