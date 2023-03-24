using UnityEngine;

public class Checkpoint : MonoBehaviour 
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _checkpointOn;
    [SerializeField] private Material _checkpointOff;

    private HealthManager _healthManager;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _healthManager = FindObjectOfType<HealthManager>();
    }

    public void CheckpointOn()
    {
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();

        foreach (Checkpoint checkpoint in checkpoints)
        {
            checkpoint.CheckpointOff();
        }

        _renderer.material = _checkpointOn;
    }

    public void CheckpointOff()
    {
        _renderer.material = _checkpointOff;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            _healthManager.SetSpawnPoint(transform.position);
            CheckpointOn();
        }
    }
}
