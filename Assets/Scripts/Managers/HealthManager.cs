using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private float _invincibilityLength;
    [SerializeField] private Text _healthText;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private GameObject _playerModel;
    [SerializeField] private float _flashLength = 0.1f;
    private float _invincibilityCounter;
    private float _flashCounter;
    private bool _isRespawning;
    private Vector3 _respawnPoint;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthText.text = "Health: " + _currentHealth;
        _respawnPoint = _player.transform.position;
    }

    private void Update()
    {
        if(_invincibilityCounter > 0)
        {
            _invincibilityCounter -= Time.deltaTime;

            _flashCounter -= Time.deltaTime;

            if(_flashCounter <= 0)
            {
                if(_playerModel.activeSelf == false)
                {
                    _playerModel.SetActive(true);
                }
                else
                {
                    _playerModel.SetActive(false);
                }

                _flashCounter = _flashLength;
            }

            if(_invincibilityCounter <= 0)
            {
                _playerModel.SetActive(true);
            }
        }
    }

    public void HurtPlayer(int damage, Vector3 direction)
    {
        if(_invincibilityCounter <= 0)
        {
            _currentHealth -= damage;

            if(_currentHealth <= 0)
            {
                Respawn();
            }
            else
            {
                _player.KnockBack(direction);

                _invincibilityCounter = _invincibilityLength;

                _playerModel.SetActive(false);

                _flashCounter = _flashLength;
            }
        }

        _currentHealth -= damage;
        _healthText.text = "Health: " + _currentHealth;
    }

    public void Respawn()
    {
        _player.transform.position = _respawnPoint;
        _currentHealth = _maxHealth;
        _healthText.text = "Health: " + _currentHealth;
    }

    public void HealingPlayer(int healAmount)
    {
        _currentHealth += healAmount;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        _respawnPoint = newPosition;
    }
}
