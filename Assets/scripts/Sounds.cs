using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [Header("----------Audio Source---------")]
    [SerializeField] AudioSource sfxSource;

    [Header("----------Audio Clip---------")]
    public AudioClip wind;
    public AudioClip fruitsCollecting;
    public AudioClip gameOver;

    public static Sounds instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
