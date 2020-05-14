using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MenuSFX : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip backSound;
    [SerializeField] AudioClip hoverSound;
    [SerializeField] AudioClip selectSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBackSound()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(backSound);
    }

    public void PlayHoverSound()
    {
        audioSource.pitch = Random.Range(0.5f, 1.5f);
        audioSource.PlayOneShot(hoverSound);
    }

    public void PlaySelectSound()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(selectSound);
    }
}
