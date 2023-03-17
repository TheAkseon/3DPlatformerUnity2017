using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _coinsText;
    private int _currentGold;

    public Vector3 lastCheckpointPosition;

    public void AddGold(int goldToAdd)
    {
        _currentGold += goldToAdd;
        _coinsText.text = "Coins: " + _currentGold;
    }
}
