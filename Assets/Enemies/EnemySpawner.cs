using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float StartTime = 1;
    public float Time = 5;
    public bool Inverted;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnEnemy", StartTime, Time);
    }

    void SpawnEnemy()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            var enemy = (GameObject)Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            var health = enemy.GetComponent<Health>();
            health.OnDie += enemy_OnDie;
            if (Inverted)
            {
                var scale = enemy.transform.localScale;
                scale.x *= -1;
                enemy.transform.localScale = scale;
            }
        }
    }

    void enemy_OnDie()
    {
        ScoreManager.Instance.EnemiesDestroyed += 1;
    }
}
