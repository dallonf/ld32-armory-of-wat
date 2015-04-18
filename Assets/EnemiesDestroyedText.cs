using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemiesDestroyedText : MonoBehaviour
{
    private Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        text.text = "Enemies Destroyed: " + ScoreManager.Instance.EnemiesDestroyed;
    }
}
