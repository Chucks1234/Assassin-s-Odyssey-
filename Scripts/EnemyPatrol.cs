using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float xSpeed;

    public Transform enemyTop;

    [SerializeField] Rigidbody2D enemyRB;
    [SerializeField] Animator anim;
    [SerializeField] private bool isMoving;
    [SerializeField] private bool facingLeft;
    [SerializeField] private bool isDead;

    

    
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingLeft = true;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead) enemyRB.velocity = new Vector2(xSpeed, enemyRB.velocity.y);
        else enemyRB.velocity = Vector2.zero;

        if (enemyRB.velocity != Vector2.zero) isMoving = true;
        else isMoving = false;

        if (enemyRB.velocity.x < 0 && !facingLeft) Flip();
        if (enemyRB.velocity.x > 0 && facingLeft) Flip();
        anim.SetBool("Moving", isMoving);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Edge") xSpeed *= -1;
    }



    void Flip()
    {
        if (facingLeft) transform.localScale = new Vector2(-5, 6.5f);
        else transform.localScale = new Vector2(5, 6.5f);

        facingLeft = !facingLeft;
    }

    

}
    



