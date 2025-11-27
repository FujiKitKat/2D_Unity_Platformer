using UnityEngine;

public class PlayerCampFire : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement =  GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        { 
            SitAtCampFire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            WalkAwayFromCampFire();
        }
    }
    private void SitAtCampFire()
    {
        _playerMovement.enabled = false;
        
        _animator.SetTrigger("SitDown");
        _animator.SetTrigger("SitByTheFire");
    }

    private void WalkAwayFromCampFire()
    {
        _playerMovement.enabled = true;
        
        _animator.SetTrigger("StandUp");
    }
}
