﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public GameObject acornPrefab;
    Vector3 acorn;
    public float speed = 5;
    public float eatDistance =1f;
    public float acornDetectionRange;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        acornPrefab = GameObject.FindGameObjectWithTag("Acorn");
        if (Vector3.Distance(acornPrefab.transform.position, this.transform.position) < acornDetectionRange) 
        {
            Vector3 direction = acornPrefab.transform.position - this.transform.position;
           // direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            float move = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, acornPrefab.transform.position, move);
        }

        if (Vector3.Distance(acornPrefab.transform.position, this.transform.position) < eatDistance)
        {
            Destroy(acornPrefab);
        }
    }
}