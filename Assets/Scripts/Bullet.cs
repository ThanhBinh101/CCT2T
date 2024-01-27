using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform player1;
    public float life = 3;
    private Rigidbody2D rb;
    public float forceApplied = 25;

    public float speed = 3.0f;

    public Vector3 direction;

    void Awake(){
        player1 = GetComponent<Transform>().parent.parent;
        Destroy(gameObject, life);
    }


    public void Initialized(Vector3 dir)
    {
        if (rb == null){rb = this.gameObject.GetComponent<Rigidbody2D>();}

        direction = dir;

        rb.velocity = Vector2.right * direction.z * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (Distance(GameObject.transform.position, collision.Game))
        GameObject player2 = collision.gameObject;
        if (player2.tag == "Player")
            Swap(player1, player2.transform);
        Destroy(gameObject);
    }
    void Swap(Transform x1, Transform x2)
    {
        Debug.Log("Swap");
        Vector3 tp = x1.position;
        x1.position = x2.position;
        x2.position = tp;
    }
}
