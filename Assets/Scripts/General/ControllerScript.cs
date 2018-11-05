using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour
{
    public static bool paused = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void setPauseState(bool value)
    {
        paused = value;
        if (value)
        {
            Time.timeScale = 0;

        }
        else
        {

            Time.timeScale =1;
        }
    }
}
