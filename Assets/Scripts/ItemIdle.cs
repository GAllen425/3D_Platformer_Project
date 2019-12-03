using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIdle : MonoBehaviour
{
    // Start is called before the first frame update

    public float rotateSpeed = 1.0f;
    public float vertSpeed = 10.0f;
    public float waitTime = 0.000001f;
    public float epsilon = 0.05f;
    public Vector3 topPosition;
    public Vector3 bottomPosition;
    public float heightDiff = 1.0f;
    public GameObject item;
    
    void Start()
    {
        item = this.gameObject;
        bottomPosition = item.transform.position;
        topPosition = bottomPosition + new Vector3(0,heightDiff,0) ;
        StartCoroutine(Move(topPosition)); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move(Vector3 target)
    {
        while (Mathf.Abs((target - transform.localPosition).y) > epsilon)
        {
            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * vertSpeed * Time.deltaTime;

            yield return null;
        }

        //yield return new WaitForSeconds(waitTime);

        Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;

        StartCoroutine(Move(newTarget));
    }
}
