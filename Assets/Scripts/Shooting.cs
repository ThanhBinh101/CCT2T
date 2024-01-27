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

    public void PUSH()
    {
        Debug.Log("PUSH");
        var push = Instantiate(pushPref, pushingPoint.position, transform.rotation);
        var pushScript = push.GetComponent<pushing>();
        pushScript.Initialized(transform.forward);
    }

    public void SHOOT()
    {
        
        Debug.Log("SHOOT");
        var bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity, transform.parent);
        var bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.Initialized(transform.forward);
    }
}
