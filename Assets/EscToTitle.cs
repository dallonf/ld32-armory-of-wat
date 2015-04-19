using UnityEngine;
using System.Collections;

public class EscToTitle : MonoBehaviour
{
    public string Scene;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (string.IsNullOrEmpty(Scene))
            {
                Debug.Log("Quitting");
                Application.Quit();
            }
            else
            {
                Application.LoadLevel(Scene);
            }
        }
    }
}
