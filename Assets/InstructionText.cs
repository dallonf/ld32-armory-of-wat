using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstructionText : MonoBehaviour
{
    public int MinToDisplay;
    public int MaxToDisplay;

    private Text text;

    public void Awake()
    {
        text = GetComponent<Text>();
        text.enabled = false;
    }

    public void FixedUpdate()
    {
        int score = ScoreManager.Instance.EnemiesDestroyed;
        if (score >= MinToDisplay)
        {
            text.enabled = true;
        }

        if (score > MaxToDisplay)
        {
            Destroy(gameObject);
        }
    }
}
