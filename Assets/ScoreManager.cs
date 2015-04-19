using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int EnemiesDestroyed = 0;
    public GameObject GameOverScreen;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Health>().OnDie += Player_OnDie;
    }

    void Player_OnDie()
    {
        GameOverScreen.SetActive(true);
    }
}
