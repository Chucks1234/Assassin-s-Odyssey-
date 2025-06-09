using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator anim; 
    public int EnemyMaxHP = 100;
    public int currentEnemyHP;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        currentEnemyHP = EnemyMaxHP;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayerAttack")
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentEnemyHP -= damage;

        anim.SetTrigger("Hurt");

        if(currentEnemyHP <= 0)
        {
             StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        audioManager.PlaySFX(audioManager.enemyMoan);
        Debug.Log("Enemy died!");

        anim.SetBool("Edead", true);

        //GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }
}        
