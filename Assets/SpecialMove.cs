using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMove : MonoBehaviour
{
    public int count1;
    public int count2;
    public int count3;
    public int count4;

    [SerializeField] public GameObject player;

    // Start is called before the first frame update
    public void Start()
    {
        count1 = count2 = count3 = count4 = 0;

    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    void useGun()
    {

    }
    

    public void usePortal() {
        if (count2 == 0) return;
        --count2;
       
    }

    public void useDoubleJump() {
        
    }
}
