using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;
    
    [SerializeField] protected AudioClip stepClip;
    [SerializeField] protected AudioClip attackClip;

    public void PlayStep() => audioSource.PlayOneShot(stepClip);
    public void PlayAttack() => audioSource.PlayOneShot(attackClip);
}
