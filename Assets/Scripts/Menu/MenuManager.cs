using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour 
{
    [SerializeField] private string _levelName;

    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(_levelName);
    }
}
