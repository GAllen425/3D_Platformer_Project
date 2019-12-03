using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAcorn : MonoBehaviour
{
    public GameObject acornPrefab;
    public ItemManager itemManager;
    public static int acornCount = 0;
    void Start()
    {
        itemManager = GameObject.Find("GameManager").GetComponent<ItemManager>();
        if (acornPrefab != null)
        {
            foreach (Transform child in transform)
            {
                spawnAcornMethod(acornPrefab,child.gameObject.transform.position,5.0f);
                acornCount++;
            }
        }
    }

    void Update()
    {
        
    }

    // Returns a random spawn position within a radius of the parent's position
    // Also checks that the spawn vector is above the ground.
    Vector3 spawnAcornMethod (GameObject obj, Vector3 parentPosition, float radiusFromParent)
    {
        float radiusOfObject = 1.0f;
        if (obj.GetComponent<Collider>() != null)
        {
            radiusOfObject = obj.GetComponent<Collider>().bounds.extents.y;
        }


        Vector3 randomDisplacement = new Vector3(Random.Range(-radiusFromParent,radiusFromParent),
                                                 0,
                                                 Random.Range(-radiusFromParent,radiusFromParent));
        
        // Select a random position around the parent e.g. around the tree
        Vector3 ret = parentPosition + randomDisplacement;

        // Ray starts 100 units above the position to find the terrain
        Ray ray = new Ray (ret + Vector3.up*1000, Vector3.down);
        int layerMask = LayerMask.GetMask("Terrain");
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider != null)
            {
                ret = new Vector3(ret.x, hit.point.y + radiusOfObject + 0.5f, ret.z);
            }
            else
            {
                Debug.Log("Out of bounds" + this.gameObject);
            }
        }
        else
        {
            Debug.Log("Raycast failed");
        }

        Instantiate(obj,
                    ret,
                    //GetSpawnPosition(child.gameObject.transform.position, 5.0f),
                    Quaternion.identity);
                    //.transform.parent = child.gameObject.transform;
        itemManager.AddItem("Acorn");
        return ret;
    }
}
