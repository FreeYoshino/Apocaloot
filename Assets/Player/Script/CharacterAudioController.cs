using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudioController : MonoBehaviour
{
    public AudioClip walkSound;
    public AudioClip jumpSound;
    public AudioClip hurtSound;
    public AudioClip deadSound;
    public AudioClip attackSound;
    private AudioSource audioSource;
    private bool isWalkSoundPlaying;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayWalkSound()
    {
        if(!isWalkSoundPlaying)
        {
            audioSource.clip = walkSound;
            audioSource.loop = true;
            audioSource.Play();
            isWalkSoundPlaying = true;
        }
    }
    public void StopWalkSound()
    {
        if (isWalkSoundPlaying)
        {
            audioSource.Stop();
            isWalkSoundPlaying=false;
        }
    }
    public void PlayJumpSound()
    {
        StopWalkSound();
        audioSource.PlayOneShot(jumpSound);
    }
    public void PlayHurtSound()
    {
        audioSource.PlayOneShot(hurtSound);
    }
    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(attackSound);
    }
    public void PlayDeadSound()
    {
        audioSource.PlayOneShot(deadSound);
    }
}
