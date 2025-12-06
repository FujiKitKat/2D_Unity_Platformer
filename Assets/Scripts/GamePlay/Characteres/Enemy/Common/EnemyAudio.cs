using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    [SerializeField]protected AudioSource audioSource;
    [SerializeField]protected AudioClip stepClip;
    [SerializeField]protected AudioClip deathClip;
    [SerializeField]protected AudioClip damageClip;
    
    public void PlayStep()  => audioSource.PlayOneShot(stepClip);
    public void PlayDeath()  => audioSource.PlayOneShot(deathClip);
    public void PlayDamage()  => audioSource.PlayOneShot(damageClip);
    
}
