using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public PlayerHealth pHealth;
    public float damage;
    public Animator animator;

    AudioManager audioManager;
    // Start is called before the first frame update

    void Start()
    {
        animator=GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            pHealth.curHealth -= damage;
            if (pHealth.curHealth > 0)
            {
                
                animator.SetTrigger("Takedmg");
                
            }
            else
            {
                
                animator.SetTrigger("isDead");
                
            }
            Destroy(gameObject);
        }
    }

    

}
