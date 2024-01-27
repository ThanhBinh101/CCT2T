using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public float speed = 3;

    public Transform pushingPoint;
    public GameObject pushPref;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            var bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            var push = Instantiate(pushPref, pushingPoint.position, transform.rotation);
            push.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }
    }
}
