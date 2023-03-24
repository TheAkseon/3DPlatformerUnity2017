using UnityEngine;

public class NextLevel : MonoBehaviour 
{
    private MenuManager _menuManager;

    private void Start()
    {
        _menuManager = FindObjectOfType<MenuManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        _menuManager.NextLevel();
    }
}
