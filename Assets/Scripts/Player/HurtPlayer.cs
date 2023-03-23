using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _gameManager.PlayDamageSound();
            FindObjectOfType<HealthManager>().HurtPlayer();
        }
    }
}
