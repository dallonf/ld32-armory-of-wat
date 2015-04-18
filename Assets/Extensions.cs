using UnityEngine;
using System.Collections;

public static class Extensions
{
    public static float GetLookAtAngle2D(this Transform transform, Vector3 target)
    {
        var diff = target - transform.position;
        float rotZ = AngleMath.VectorToAngle2D(diff);
        return rotZ;
    }
}

public static class AngleMath
{
    public static float VectorToAngle2D(Vector3 vector)
    {
        return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
    }
}

public static class PhysicsUtil
{
    public static void AddExplosionForce2D(Rigidbody2D rigidbody2d, float explosionForce, Vector3 explosionPosition, float explosionRadius)
    {
        var dir = (rigidbody2d.transform.position - explosionPosition);
        float wearoff = 1 - (dir.magnitude / explosionRadius);
        rigidbody2d.AddForce(dir.normalized * explosionForce * wearoff);
    }
}