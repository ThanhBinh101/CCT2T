using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public float speed = 3;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            var bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }
    }
}
