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
