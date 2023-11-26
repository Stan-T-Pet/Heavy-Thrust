using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Initialization code (if needed)
    }

    // Update is called once per frame
    void Update()
    {
        // Update code (if needed)
    }

    // OnTriggerEnter is called when a Collider enters this object's trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Destroy the gameObject when a collision occurs
        Destroy(gameObject);
    }
}
