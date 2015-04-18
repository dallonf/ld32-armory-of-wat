using UnityEngine;
using System.Collections;

public class MetaGunController : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float ShotsToFire = 3;
    public float DelayToFire = 0.5f;
    public float DelayBetweenShots = 0.25f;
    public float TimeAfterFire = 1;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(FireWeapon());
    }

    IEnumerator FireWeapon()
    {
        yield return new WaitForSeconds(DelayToFire);
        for (int i = 0; i < ShotsToFire; i++)
        {
            Debug.Log("Shoot");
            yield return new WaitForSeconds(DelayBetweenShots);
        }
        yield return new WaitForSeconds(TimeAfterFire);
        Destroy(gameObject);
    }
}
