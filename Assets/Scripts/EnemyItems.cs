using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItems : MonoBehaviour
{
 
    public Scoring scoring;

    void Start()
    {
        scoring = GameObject.Find("GameManager").GetComponent<Scoring>();
    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("EATING ACORN");
            Destroy(this.gameObject);
            scoring.RemoveRemainingScore();

        }
    }
}
