using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMove : MonoBehaviour
{
    public int count1;
    public int count2;
    public int count3;
    public int count4;

    // Start is called before the first frame update
    void Start()
    {
        count1 = count2 = count3 = count4 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void usePortal() {
        if (count2 > 0) {
            //portal ability here
        } else {
            Debug.Log ("Out of stock!");
        }
    }

    void useDoubleJump() {
        if (count1 > 0) {

        } else {
            Debug.Log ("Out of stock!");
        }
    }
}
