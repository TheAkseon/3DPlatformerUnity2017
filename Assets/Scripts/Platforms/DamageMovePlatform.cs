using UnityEngine;

public class DamageMovePlatform : MonoBehaviour
{
    [SerializeField] private int _amplitude = 1;
    [SerializeField] private float _frequency = 0.1f;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        float x = Mathf.Cos(Time.time * _frequency) * _amplitude;
        float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
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
