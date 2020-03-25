using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // What is the maximum speed we want Bob to walk at
    private float moveSpeed = 5f;
    private float DirX;

    // Start facing right (like the sprite-sheet)
    private bool facingRight = true;

    // This will be a reference to the RigidBody2D 
    // component in the Player object
    private Rigidbody2D rb;

    // This is a reference to the Animator component
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // Take the reference to the respective component
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Get the extent to which the player is currently pressing left or right
        DirX = Input.GetAxis("Horizontal") * moveSpeed;

        // Move the RigidBody2D (which holds the player sprite)
        // on the x axis based on the state of input and the moveSpeed variable
        rb.velocity = new Vector2(DirX, rb.velocity.y);

        // Player pressed jump and is not currently airborne
        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * 350f);
        // Player is moving on X axis and not airborne
        if (Mathf.Abs(rb.velocity.x) > 0 && rb.velocity.y == 0)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);
        // Player is not airborne
        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
        // Player is going up
        if (rb.velocity.y > 0)
            anim.SetBool("isJumping", true);
        if (rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(DirX, rb.velocity.y);
        // Check which way the player is facing 
        // and call reverseImage if neccessary
        if (DirX > 0 && !facingRight)
            ReverseImage();
        else if (DirX < 0 && facingRight)
            ReverseImage();
    }

    void ReverseImage()
    {
        // Switch the value of the Boolean
        facingRight = !facingRight;

        // Get and store the local scale of the RigidBody2D
        Vector2 theScale = rb.transform.localScale;

        // Flip it around the other way
        theScale.x *= -1;
        rb.transform.localScale = theScale;
    }
}
