using UnityEngine;

public class FireAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    
    [SerializeField] protected AudioClip fireSound;
    
    public void PlayFireSound() => audioSource.PlayOneShot(fireSound);
}
