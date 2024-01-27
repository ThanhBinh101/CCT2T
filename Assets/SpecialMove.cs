using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
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

    }

    public void OnUsePortal(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            usePortal();
        }
    }

    public void OnUseJumpPush(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            useJumpPush();
        }
    }

    public void useGun()
    {
        
    }
    

    public void usePortal() {
        //if (count2 == 0) return;
        --count2;
        Instantiate(portal, new Vector2(player.transform.position.x - 2f, player.transform.position.y), Quaternion.identity);
    }

    public void useJumpPush() {
        if (count3 == 0) {
            Debug.Log("Out of stock!");
            return;
        }
        --count3;
        float jumpForce = GetComponent<CharacterMovement>().jumpForce * 2;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }
}
