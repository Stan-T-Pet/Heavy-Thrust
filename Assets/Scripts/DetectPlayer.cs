/**
 * find player based on :  https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
 * **/

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
        }//fixxx
    }

    public GameObject FindPlayer()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Palyer");
        GameObject closest = null;
        float distance = Mathf.Infinity;

        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    void shoot() 
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        //transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }
}
