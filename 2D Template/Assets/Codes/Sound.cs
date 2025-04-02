using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound instance;

    [SerializeField] private AudioSource soundFXObjectWalk;
    [SerializeField] private AudioSource soundFXObjectRun;

    private bool canPlaySound = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        if (!canPlaySound)
        {
            return;
        }

        canPlaySound = false;

        AudioSource audioSource = Instantiate(soundFXObjectWalk, spawnTransform.position, Quaternion.identity);
        AudioSource _ = Instantiate(soundFXObjectRun, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;
        _.clip = audioClip;

        audioSource.volume = volume;
        _.volume = volume;

        audioSource.Play();
        _.Play();

        float clipLength = audioSource.clip.length;
        float _clipLength = _.clip.length;


        Destroy(audioSource.gameObject, clipLength);
        Destroy(_.gameObject, _clipLength);

        Invoke(nameof(ResetSound), clipLength);
    }

    private void ResetSound()
    {
        canPlaySound = true;
    }

}
