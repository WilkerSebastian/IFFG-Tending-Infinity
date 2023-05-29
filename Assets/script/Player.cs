using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 3f;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float jumpTimeCounter;
    public float jumpTime = 0.35f;
    public float jumpForce = 10;
    private bool isJumping;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {

        Debug.Log(isJumping);

        float horizontal = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector2(horizontal, 0).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) {

            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;        

        }

        if(horizontal != 0 && !isJumping) {

            animator.SetBool("runner", true);

        } else {

            animator.SetBool("runner", false);

        }

        if (moveDirection.x > 0) {

            spriteRenderer.flipX = false;

        }
        else if (moveDirection.x < 0) {

            spriteRenderer.flipX = true;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Ground") {

            isJumping = false;

        }

    }

    private void OnCollisionExit2D(Collision2D collision) {
    
        if (isJumping && collision.gameObject.tag == "Ground") {

            isJumping = true;

        }

    }

    private void FixedUpdate() {

        Vector2 velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);
        rb.velocity = velocity;
        animator.SetBool("jumping", isJumping);

    }

}
