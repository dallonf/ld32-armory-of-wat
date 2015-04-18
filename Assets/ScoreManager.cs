using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int EnemiesDestroyed = 0;

    // Use this for initialization
    void Start()
    {
        Instance = this;
    }
}
