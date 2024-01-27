using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform destination;
    public bool isBlue;
    public float distance = 0.2f;

    private void Start()
    {
        if (isBlue)
        {
            destination = GameObject.FindGameObjectWithTag("GreenPortal").GetComponent<Transform>();

        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("BluePortal").GetComponent<Transform>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Vector2.Distance(transform.position, other.transform.position) > distance)
        {
            other.transform.position = new Vector2(destination.position.x, destination.position.y);

        }
    }


}
