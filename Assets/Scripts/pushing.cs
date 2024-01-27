using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushing : MonoBehaviour
{
    public float life = 1;
    private Rigidbody2D rb;
    public float speed = 3.0f;
    public Vector3 direction;

    void Awake(){
        Destroy(gameObject, life);
    }

    public void Initialized(Vector3 dir){
        if (rb == null){rb = this.gameObject.GetComponent<Rigidbody2D>();}

        direction = dir;

        rb.velocity = Vector2.right * direction.z * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        var rb2d = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb2d != null)
            rb2d.AddForce(new Vector2(direction.z, 7f), ForceMode2D.Impulse);
        Destroy(gameObject);
    }

    
}
