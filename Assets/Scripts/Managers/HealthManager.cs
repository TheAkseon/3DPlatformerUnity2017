using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private float _invincibilityLength;
    private float _invincibilityCounter;
    private float _flashCounter;
    private bool _isRespawning;
    private Vector3 _respawnPoint;

    public int maxHealth;
    public int currentHealth;
    public GameObject _playerModel;
    public float flashLength = 0.1f;

    private void Start()
    {
        currentHealth = maxHealth;

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

                _flashCounter = flashLength;
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
            currentHealth -= damage;

            if(currentHealth <= 0)
            {
                Respawn();
            }
            else
            {
                _player.KnockBack(direction);

                _invincibilityCounter = _invincibilityLength;

                _playerModel.SetActive(false);

                _flashCounter = flashLength;
            }
        }
    }

    public void Respawn()
    {
        _player.transform.position = _respawnPoint;
        currentHealth = maxHealth;
    }

    public void HealingPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
