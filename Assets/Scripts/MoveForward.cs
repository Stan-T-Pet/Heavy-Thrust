using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
   public float turnSpeed = 30.0f;
     public float HorizontalInput; 
     public float forwardInput;
    //adding speed variable
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //This where we create all our inputs
        HorizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        
        //This moves the boat forward
        transform.Translate(Vector3.forward*Time.deltaTime*speed*forwardInput);
        //This makes the boat rotate
        transform.Rotate(Vector3.up,Time.deltaTime*turnSpeed*HorizontalInput);
        
    }
}
