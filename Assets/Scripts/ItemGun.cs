using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGun : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            SpecialMove player = other.GetComponent<SpecialMove>();
            if (player.count3 < 5) {
                ++player.count4;
                gameObject.SetActive(false);             
            }
        }
    }
}
