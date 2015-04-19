using UnityEngine;
using System.Collections;

public class ClickToAdvance : MonoBehaviour
{
    public string SceneToGoTo;
    public float MinTime = 0;

    private float timeAlive;

    // Update is called once per frame
    void Update()
    {
        if (timeAlive > MinTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Application.LoadLevel(SceneToGoTo);
            }
        }
        else
        {
            timeAlive += Time.deltaTime;
        }
    }
}
