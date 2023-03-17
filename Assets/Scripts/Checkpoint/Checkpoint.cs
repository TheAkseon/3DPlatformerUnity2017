using UnityEngine;

public class Checkpoint : MonoBehaviour 
{
	private LevelCheckpoints _levelCheckpoints;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			_levelCheckpoints.PlayerThroughCheckpoint(this);
		}
	}

	public void SetLevelCheckpoints(LevelCheckpoints levelCheckpoints)
	{
		_levelCheckpoints = levelCheckpoints;
	}
}
