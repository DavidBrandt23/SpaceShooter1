using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    
    void Start()
    {
    }

    public void PlayClicked()
    {
        SceneManager.LoadScene("Scene1");
        ControllerScript.setPauseState(false);
    }
    public void QuitClicked()
    {
        Application.Quit();
    }
}
