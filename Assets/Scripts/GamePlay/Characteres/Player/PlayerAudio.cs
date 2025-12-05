using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;
    
    [SerializeField] protected AudioClip stepClip;
    [SerializeField] protected AudioClip attackClip;
    [SerializeField] protected AudioClip damageClip;
    [SerializeField] protected AudioClip deathClip;

    public void PlayStep() => audioSource.PlayOneShot(stepClip);
    public void PlayAttack() => audioSource.PlayOneShot(attackClip);
    public void PlayDamage() => audioSource.PlayOneShot(damageClip);
    public void PlayDeath() => audioSource.PlayOneShot(deathClip);
    
}
