/***
 * 1) find * with tag: https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
 * 1.5) https://forum.unity.com/threads/how-to-find-a-gameobject-by-tag.172188/
 * 2) https://youtu.be/--u20SaCCow?t=440
 ***/


using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
        rigBod = GetComponent<rigBod>();
        player = gameObject.FindGameObjectWithTag("Player") //using "Player" tag to find position of player

        //giving bullet direction to go in
        Vector3 direction = player.transform.posistion - transform.position;
        rigBod.velocity = new Vector2(direction.x, direction.y).normalised * bulletSpeed; //setting bullet speed and ensuring it flies in straight line wth "normalised"

        float rot = Mathf.Atan2(-direction.x, direction.y) * MathF.Rad2Deg;
        trasform.rotation = Quaternion.Euler(0,0,rot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
