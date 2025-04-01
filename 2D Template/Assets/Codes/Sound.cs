using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip WalkingSoundClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource.clip = WalkingSoundClip;
        audioSource?.Play();
    }
}
