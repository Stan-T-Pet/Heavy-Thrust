using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    //game boundaries
    private float topBound = 35;
    private float lowBound = -12;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }else if (transform.position.z < lowBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
