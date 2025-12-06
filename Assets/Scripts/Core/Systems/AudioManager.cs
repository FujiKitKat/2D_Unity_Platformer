using UnityEngine;
using UnityEngine.LowLevel;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager  instance{get; private set;}
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip mainMenuMusic;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);
        
        audioSource = GetComponent<AudioSource>();
    }

    public void MainMenuSong()
    {
        PlayLoop(mainMenuMusic);
    }

    private void PlayLoop(AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }
        
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
