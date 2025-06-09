using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Collider2D SwordCollider;
    public Animator animator;
    
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        SwordCollider.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameisPaused) return;

        if (Input.GetMouseButtonDown(1))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            StartCoroutine(Attack());

        }
        
    }

    IEnumerator Attack()
    {
        audioManager.PlaySFX(audioManager.SwordSwoosh);
        animator.SetTrigger("isAttacking");
        SwordCollider.enabled = true;
        yield return new WaitForSeconds(0.2f);
        SwordCollider.enabled = false;

      
    }

    
    
}
