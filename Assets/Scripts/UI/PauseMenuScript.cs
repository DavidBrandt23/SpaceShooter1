using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject PauseMenu;
    void Start()
    {
    }
    public void Update()
    {
        if (Input.GetButton("Pause"))
        {
            PauseMenu.SetActive(true);
            ControllerScript.setPauseState(true);
        }
    }
    public void ResumeClicked()
    {
        PauseMenu.SetActive(false);
        ControllerScript.setPauseState(false);
    }
    public void MainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitClicked()
    {
        Application.Quit();
    }
}
