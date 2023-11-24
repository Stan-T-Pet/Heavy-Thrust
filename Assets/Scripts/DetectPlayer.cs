using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPos;
    private float rateOfFire;
    public float bulletSpeed = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rateOfFire += Time.deltaTime;
        if (rateOfFire > 2 )
        {
            rateOfFire = 0;
            shoot();
        }
    }
    void shoot() 
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        //transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }
}
