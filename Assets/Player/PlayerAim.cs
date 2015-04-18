﻿using UnityEngine;
using System.Collections;

public class PlayerAim : MonoBehaviour
{
    public float MinTargetDistance = 1;
    public Transform GunPointer;

    void Awake()
    {
        GunPointer = transform.FindChild("gun-pointer");
    }

    void FixedUpdate()
    {
        Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawLine(transform.position, mousePositionInWorld, Color.blue);

        var diff = mousePositionInWorld - (Vector2)GunPointer.position;
        if (diff.sqrMagnitude < MinTargetDistance * MinTargetDistance)
        {
            diff = mousePositionInWorld - (Vector2)transform.position;
        }

        var angle = AngleMath.VectorToAngle2D(diff);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void OnDrawGizmos()
    {
        if (GunPointer)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(GunPointer.position, GunPointer.TransformDirection(Vector3.up) * 100);
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, MinTargetDistance);
    }
}