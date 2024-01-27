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
    [SerializeField] public GameObject portal;
    // Start is called before the first frame update
    public void Start()
    {
        count1 = count2 = count3 = count4 = 0;

    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)) {
            usePortal();
        }
    }

    void useGun()
    {
        
    }
    

    public void usePortal() {
        //if (count2 == 0) return;
        --count2;
        Instantiate(portal, new Vector2(player.transform.position.x - 2f, player.transform.position.y), Quaternion.identity);
    }

    public void useDoubleJump() {
        if (count3 == 0) return;
        --count3;
    }
}
