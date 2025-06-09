using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Respawn respawn;
    private BoxCollider2D checkPointCollider;
    public Animator anim;

    AudioManager audioManager;
    // Start is called before the first frame update
    void Awake()
    {
        checkPointCollider = GetComponent<BoxCollider2D>();
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Respawn>();
        audioManager =GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.checkPoint);
            respawn.respawnPoint = this.gameObject;
            checkPointCollider.enabled = false;
            anim.SetTrigger("PointReached");
        }

    }
}

