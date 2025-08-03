using UnityEngine;

public class SounManager : MonoBehaviour
{
    public static SounManager Instance;
    [SerializeField] AudioClip bouncSound;
    AudioSource audioSource;
    bool isPlaying;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isPlaying = false;
    }


    void Update()
    {
        if (!isPlaying)
        {
            PlaySound();
            isPlaying = true;
        }
    }

    void PlaySound()
    {
        audioSource.Play();
    }

    public void StopSount()
    {
        audioSource.Stop();
        isPlaying = !isPlaying;
    }

    public void BounceSound()
    {
        audioSource.PlayOneShot(bouncSound);
    }
}
