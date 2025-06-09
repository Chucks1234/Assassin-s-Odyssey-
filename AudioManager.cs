using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------- Audio Source ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------- Audio Clip ----------")]
    public AudioClip Level01;
    public AudioClip PowerUP;
    public AudioClip GameOver;
    public AudioClip SwordSwoosh;
    public AudioClip playerHit;
    public AudioClip playerDeath;
    public AudioClip enemyMoan;
    public AudioClip portal;
    public AudioClip checkPoint;
    public AudioClip EnemyRoam;

    private void Start()
    {
        musicSource.clip = Level01;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
