/***
 * 1) find * with tag: https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
 * 1.5) https://forum.unity.com/threads/how-to-find-a-gameobject-by-tag.172188/
 * 2) https://youtu.be/--u20SaCCow?t=440
 ***/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private GameObject player;//player obj reference to point bullet at
    private Rigidbody rigBod;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //
        rigBod = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player"); //using "Player" tag to find position of player

        //giving bullet direction and location to go in
        Vector3 direction = player.transform.position - transform.position;
        rigBod.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed; //setting bullet speed and ensuring it flies in straight line wth "normalised"

        //rotating bullet in player direction
        float rot = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
