using UnityEngine;

public class CampFireInteraction : MonoBehaviour
{
    private bool _playerInZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerInZone = false;
        }
    }

}
