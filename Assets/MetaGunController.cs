using UnityEngine;
using System.Collections;

public class MetaGunController : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float ShotsToFire = 3;
    public float DelayToFire = 0.5f;
    public float DelayBetweenShots = 0.25f;
    public float TimeAfterFire = 1;

    public Transform LaunchPoint;

    // Use this for initialization
    void Start()
    {
        LaunchPoint = transform.FindChild("launch-point");
        StartCoroutine(FireWeapon());
    }

    IEnumerator FireWeapon()
    {
        yield return new WaitForSeconds(DelayToFire);
        for (int i = 0; i < ShotsToFire; i++)
        {
            GameObject.Instantiate(BulletPrefab, LaunchPoint.position, LaunchPoint.rotation);
            yield return new WaitForSeconds(DelayBetweenShots);
        }
        yield return new WaitForSeconds(TimeAfterFire);
        Destroy(gameObject);
    }
}
