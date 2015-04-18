using UnityEngine;
using System.Collections;

public class ClickToLaunch : MonoBehaviour
{
    public Rigidbody2D LaunchPrefab;
    public Transform LaunchPoint;
    public float LaunchForce;

    public float MinRotation = 30;
    public float MaxRotation = 270;

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

            float rotation = Random.RandomRange(MinRotation, MaxRotation);
            if (Random.value > 0.5)
            {
                rotation *= -1;
            }

            instance.AddTorque(rotation);
        }
    }
}
