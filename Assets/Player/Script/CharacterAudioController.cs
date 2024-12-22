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
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayWalkSound()
    {
        audioSource.clip = walkSound;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void StopWalkSound()
    {
        audioSource.Stop();
    }
    public void PlayJumpSound()
    {
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
