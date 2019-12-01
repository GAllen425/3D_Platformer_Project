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
        gravity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camRight = cam.transform.right;
        Vector3 camForward = cam.transform.forward;

        // inputVector = new Vector3(Input.GetAxis("Horizontal") * movespeed, -gravity,  Input.GetAxis("Vertical")* movespeed);
        
        Vector3 moveVector =   camForward * movespeed * Input.GetAxis("Vertical") + camRight * movespeed  * Input.GetAxis("Horizontal") - this.transform.up*gravity;
        Vector3 xzVector = new Vector3(1, 0, 1);
        transform.LookAt(this.transform.position + new Vector3( moveVector.normalized.x * xzVector.x , -gravity, moveVector.normalized.z * xzVector.z));
        //  transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
    
      //  transform.rotation  = Quaternion.AngleAxis(cam.transform.rotation.y + transform.rotation.y, Vector3.up );
          rigid.velocity = moveVector;
        
        }
         
     
    }

   

