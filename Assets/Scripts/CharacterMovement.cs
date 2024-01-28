using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementInput1;
    private Vector2 movementInput2;
    private Vector2 movementInput;
    float left, right, left2, right2;
    private Animator anim;
    private bool isJumping1;
    private bool isJumping2;
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
        OnMove();
        OnJump();
        Move();
        CheckGrounded();
    }

    void CheckGrounded()
    {
        Vector3 playerPosition = cTransform.position - new Vector3(0f, 0.4f, 0f);
        isGrounded = Physics2D.OverlapCircle(playerPosition, 0.2f, groundLayer);
        isOnEdge = Physics2D.OverlapCircle(cTransform.position, 0.7f, edgeLayer);
    }

    void Move()
    {
        if(this.tag == "Player") {
            movementInput = movementInput1;
            isJumping = isJumping1;
        }
        else if(this.tag == "Player2") {
            movementInput = movementInput2;
            isJumping = isJumping2;
        }

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
        if(isGrounded) 
        {
            anim.SetBool("isJumping", false);
        } else anim.SetBool("isJumping", true);

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

    public void OnMove()
    {   left = right = left2 = right2 = 0;
        if (Input.GetKey(KeyCode.D)) right = 1;
        if (Input.GetKey(KeyCode.A)) left = 1;
        if (Input.GetKey(KeyCode.RightArrow)) right2 = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) left2 = 1;
        movementInput1 = new Vector2(right-left, 0);
        movementInput2 = new Vector2(right2-left2, 0);
    }

    public void OnJump()
    {
        isJumping1 = isJumping2 = isJumping;
        if (Input.GetKeyDown(KeyCode.W))
        {   
            Debug.Log("Player1 Jump");
            if (isGrounded) {
                isJumping1 = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Debug.Log("Player2 Jump");
            if (isGrounded) {
                isJumping2 = true;
            }
        }
    }
}
