using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    private bool _isRespawning;
    private Vector3 _respawnPoint;
    public float respawnLength;

    public void HurtPlayer()
    {
        Respawn();
    }

    public void Respawn()
    {
        if (!_isRespawning)
        {
            StartCoroutine("RespawnCo");
        }
    }

    public IEnumerator RespawnCo()
    {
        _isRespawning = true;
        _player.gameObject.SetActive(false);

        yield return new WaitForSeconds(respawnLength);

        _isRespawning = false;
        _player.transform.position = _respawnPoint;
        _player.gameObject.SetActive(true);
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        _respawnPoint = newPosition;
    }
}
