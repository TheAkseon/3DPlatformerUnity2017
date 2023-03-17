using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour 
{
    private HealthManager _healthManager;

    private void Start()
    {
        _healthManager = FindObjectOfType<HealthManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            _healthManager.SetSpawnPoint(transform.position);
        }
    }
}
