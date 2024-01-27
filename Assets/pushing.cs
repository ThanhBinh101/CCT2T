using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushing : MonoBehaviour
{

    public float life = 1;
    private Rigidbody2D rb;

    void Awake(){
        Destroy(gameObject, life);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(5f, 0f), ForceMode2D.Impulse);
        // Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
