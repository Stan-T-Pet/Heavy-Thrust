using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{

    public GameObject bullet;//reference to Bullet
    public Transform bulletPos;//reference to BulletPos
    public GameObject player;//reference to player
    private float rateOfFire;
    public float shootingRange = 100.0f; //Range within the enemy detects the player

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
            Shoot();
        }
    }

    bool PlayerRange(){
        //Check if player is within range
        return Vector3.Distance(transform.position, player.transform.position) <= shootingRange;
    }
    void Shoot() 
    {
        //Makes bulletpos look at the player
        bulletPos.LookAt(player.transform.position);

        //instantiate new Bullet
        GameObject newBullet = Instantiate(bullet,bulletPos.position, bulletPos.rotation);

    }
}
