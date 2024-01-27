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
        // if (Distance(GameObject.transform.position, collision.Game))
        var rb2d = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb2d != null){
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(3f * direction.z, 0f), ForceMode2D.Impulse);
        }
        // Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
