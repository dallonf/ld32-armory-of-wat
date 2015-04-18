using UnityEngine;
using System.Collections;

public class ClickToLaunch : MonoBehaviour
{
    public Rigidbody2D LaunchPrefab;
    public Transform LaunchPoint;
    public float LaunchForce;

    void Awake()
    {
        LaunchPoint = transform.FindChild("launch-point");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var instance = (Rigidbody2D)GameObject.Instantiate(LaunchPrefab, LaunchPoint.position, LaunchPoint.rotation);
            instance.AddForce(LaunchForce * LaunchPoint.right);
        }
    }
}
