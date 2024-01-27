using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Animator anim;
    private bool isJumping;
    private bool isGrounded;
    private bool isOnEdge;
    private bool isFacingLeft;

    public Transform cTransform;
    public LayerMask groundLayer;
    public LayerMask edgeLayer;
    public float speed = 2f;
    public float jumpForce = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isFacingLeft = false;
        isJumping = false;
    }

    void FixedUpdate()
    {
        Move();
        CheckGrounded();
        //Debug.Log(isGrounded);
    }

    void CheckGrounded()
    {
        Vector3 playerPosition = cTransform.position - new Vector3(0f, 0.4f, 0f);
        isGrounded = Physics2D.OverlapCircle(playerPosition, 0.2f, groundLayer);
        isOnEdge = Physics2D.OverlapCircle(cTransform.position, 0.7f, edgeLayer);
    }

    void Move()
    {
        Vector2 moveDirection = new Vector2(movementInput.x, 0);
        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);

        //Facing
        if (movementInput.x < 0 && !isFacingLeft) {
            cTransform.Rotate(0f, 180f, 0f);
            isFacingLeft = true;
        }

        if (movementInput.x > 0 && isFacingLeft) {
            cTransform.Rotate(0f, 180f, 0f);
            isFacingLeft = false;
        }

        //Animate
        if (movementInput.x != 0)
        {   
            anim.SetBool("isWalking", true);
        } else anim.SetBool("isWalking", false);

        //Jumping
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = false;
        }

        //Loi on edge
        if (isOnEdge)
        {   
            if(rb.velocity.y == 0) {
                rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y-4f);
            }
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {   
            if (isGrounded) {
                //Debug.Log("Jump");
                isJumping = true;
            }
        }
    }
}
