using System.Collections.Generic;
using UnityEngine;

public class LevelCheckpoints : MonoBehaviour 
{
    private Player _player;
    private List<Checkpoint> _checkpointList;
    private int nextCheckpointIndex;

    private void Awake()
    {
        _player = FindObjectOfType<Player>().GetComponent<Player>();

        Transform checkpointsTransform = transform.Find("Checkpoints");

        _checkpointList = new List<Checkpoint>();
        foreach (Transform checkpointTransform in checkpointsTransform)
        {
            Checkpoint checkpoint = checkpointTransform.GetComponent<Checkpoint>();
            checkpoint.SetLevelCheckpoints(this);

            _checkpointList.Add(checkpoint);
        }

        nextCheckpointIndex = 0;

        _player.gameObject.transform.position = _checkpointList[nextCheckpointIndex].transform.position;
    }

    public void PlayerThroughCheckpoint(Checkpoint checkpoint)
    {
        if(_checkpointList.IndexOf(checkpoint) == nextCheckpointIndex)
        {
            Debug.Log("Correct");
            nextCheckpointIndex = (nextCheckpointIndex + 1) % _checkpointList.Count;
        }
        else
        {
            Debug.Log("Wrong");
        }
    }
}
