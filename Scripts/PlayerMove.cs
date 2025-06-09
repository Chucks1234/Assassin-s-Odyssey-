using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float Move;
    public float speed;
    public float jump;
    public bool isFacingRight;
    public Animator amin;
    public bool canDoubleJump;
    public bool isGrounded;
    public LayerMask thisIsGround;
    public Transform groundCheck;

    // Start is called before the first frame update

    void Start()
    {
        isFacingRight = true;
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.GameisPaused) return;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, thisIsGround);

        if(isGrounded)
        {
            canDoubleJump = true;
        }
        amin.SetBool("Grounded", isGrounded);

        Move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.AddForce(new Vector2(rb.velocity.x, jump));
            }
            else if (canDoubleJump)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(rb.velocity.x, jump));
                canDoubleJump = false;
            }
                    
            
        }

        if(Move >= 0.1f || Move <= -0.1f)
        {
            amin.SetBool("isRunning", true);
        }
        else
        {
            amin.SetBool("isRunning", false);
        }

        if (!isFacingRight && Move > 0f)
        {
            Flip();
        }
        else if (isFacingRight && Move < 0f)
        {
            Flip();
        }


    }
    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            amin.SetBool("Grounded", isGrounded);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            amin.SetBool("Grounded", isGrounded);
        }
    }
    */
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }



}
