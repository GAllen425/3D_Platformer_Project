using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItems : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            Destroy(this.gameObject);


        }
    }
}
