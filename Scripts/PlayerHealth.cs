using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public PlayerHealth pHealth;
    public float maxHealth;
    public Image HealthBar;
    public float curHealth;
    public Animator animator;
    public GameManager gameManager;
    public bool canHurt;
    private bool isDead;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        canHurt = true;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = Mathf.Clamp(curHealth / maxHealth, 0, 1);       

    }

    public void TakeDamage(float _dmg)
    {
        if (canHurt)
        {
            curHealth -= _dmg;
            if (curHealth > 0)
            {
                audioManager.PlaySFX(audioManager.playerHit);
                canHurt = false;
                animator.SetTrigger("Takedmg");
                StartCoroutine(ToggleDamage());
            }
            else
            {
                StartCoroutine(PlayerDead());
            }
        }
    }

    IEnumerator ToggleDamage()
    {
        yield return new WaitForSeconds(1.5f);
        canHurt = true;
    }

    IEnumerator PlayerDead()
    {
        audioManager.PlaySFX(audioManager.playerDeath);
        isDead = true; 
        //gameObject.SetActive(false);
        animator.SetTrigger("isDead");
        //Destroy(gameObject);
        yield return new WaitForSeconds(1.5f);
        gameManager.gameOver();
    }
}
