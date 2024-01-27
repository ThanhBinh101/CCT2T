using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPortal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            SpecialMove player = other.GetComponent<SpecialMove>();
            if (player.count2 < 5) {
                ++player.count2;
                gameObject.SetActive(false);             
            }
        }
    }
}
