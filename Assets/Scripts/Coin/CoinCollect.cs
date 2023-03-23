using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private GameObject _pickupEffect;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private int _coinCost;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _gameManager.PlayCollectCoinSound();
            FindObjectOfType<GameManager>().AddGold(_coinCost);
            Instantiate(_pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
