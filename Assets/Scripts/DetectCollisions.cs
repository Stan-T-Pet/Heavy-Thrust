using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollisions : MonoBehaviour
{
  
    void Start()
    {
        
    }
     
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Player")){
            
              SceneManager.LoadScene("Lose");//End of round Load next Scene
        }
        
       Destroy(gameObject);
    }
}
