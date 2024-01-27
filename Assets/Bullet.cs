using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    private Rigidbody2D rb;
    public float forceApplied = 25;

    void Awake(){
        Destroy(gameObject, life);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        var rb2d = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb2d != null)
            rb2d.AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
        // Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
