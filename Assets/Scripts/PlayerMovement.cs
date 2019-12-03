using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float verticalVelocity;
    private float gravity;
    
    public float movespeed;
    public Rigidbody rigid;
    Vector3 inputVector;
    public GameObject cam;
    

    // Start is called before the first frame update
    void Start()
    {
        
       rigid = this.GetComponent<Rigidbody>();
        movespeed = 4f;
        gravity = .0f;
    }

    // Update is called once per frame
    void Update()
    {

        inputVector = new Vector3(Input.GetAxis("Horizontal") * movespeed, 0,  Input.GetAxis("Vertical")* movespeed);

        transform.LookAt(this.transform.position + GetCameraTurn() * inputVector);
        rigid.velocity = GetCameraTurn() * inputVector - new Vector3(0,gravity,0);
        
    }
         
    private Quaternion GetCameraTurn()
    {
        return Quaternion.AngleAxis(cam.transform.rotation.eulerAngles.y,Vector3.up).normalized;
    }
     
}

   

