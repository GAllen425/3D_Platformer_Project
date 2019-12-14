using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public Scoring scoring;
    public GameObject acornPrefab;
    Vector3 acorn;
    public float speed = 5;
    public float eatDistance =1f;
    public float acornDetectionRange;
    // Start is called before the first frame update
    void Start()
    {
        scoring = GameObject.Find("GameManager").GetComponent<Scoring>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.playerActive)
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
                Debug.Log("Acorn eaten by wolf");
                scoring.RemoveRemainingScore();
                Destroy(acornPrefab);
            }
        }

        /* if (Vector3.Distance(acornPrefab.transform.position, this.transform.position) < eatDistance)
        {
            Debug.Log("EATING ACORN");
           // Destroy(acornPrefab);
            scoring.RemoveRemainingScore();
        }*/
    }
}
