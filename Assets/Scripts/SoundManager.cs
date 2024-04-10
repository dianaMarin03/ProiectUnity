using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(audioSource);
    }

    void Update()
    {

    }
    public bool checkIfIsPlaying(AudioClip audioClip)
    {
        return audioSource.isPlaying;
    }
    public void StopSound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Stop();
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

}
