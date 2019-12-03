using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    // Start is called before the first frame update

    public Dictionary<string,int> itemDictionary;
    public Scoring scoring;
    void Start()
    {
        itemDictionary = new Dictionary<string,int>();
        scoring = GameObject.Find("GameManager").GetComponent<Scoring>();
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

        if (name == "Acorn")
        {
            scoring.AddPlayerScore();
            scoring.RemoveRemainingScore();
        }
    }
}
