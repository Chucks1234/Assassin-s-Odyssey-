using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    PlayerHealth playerHealth;

    public float healthbonus = 15f;

    AudioManager audioManager;

    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (playerHealth.curHealth < playerHealth.maxHealth)
        {
            audioManager.PlaySFX(audioManager.PowerUP);
            Destroy(gameObject);
            playerHealth.curHealth = playerHealth.curHealth + healthbonus;
        }
    }


}

