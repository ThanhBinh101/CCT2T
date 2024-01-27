using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private bool isJumping;
    private bool isGrounded;
    private bool isOnEdge;

    public Transform cTransform;
    public LayerMask groundLayer;
    public LayerMask edgeLayer;
    public float speed = 5f;
    public float jumpForce = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
        CheckGrounded();
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(cTransform.position, 0.7f, groundLayer);
        isOnEdge = Physics2D.OverlapCircle(cTransform.position, 0.7f, edgeLayer);
    }

    void Move()
    {
        Vector2 moveDirection = new Vector2(movementInput.x, 0);
        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = false;
        }

        if (isOnEdge)
        {   
            Debug.Log("On edge");
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
                isJumping = true;
            }
        }
    }
}
