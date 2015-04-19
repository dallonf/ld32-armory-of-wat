using UnityEngine;
using System.Collections;

public class PlayerAim : MonoBehaviour
{
    public float MinTargetDistance = 1;
    public Transform GunPointer;

    private Vector3 gunPointerOffset;

    void Awake()
    {
        GunPointer = transform.FindChild("gun-pointer");
    }

    public void Start()
    {
        gunPointerOffset = GunPointer.transform.localPosition;
    }

    void FixedUpdate()
    {
        Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var diff = mousePositionInWorld - (Vector2)(transform.position + gunPointerOffset);
        //if (diff.sqrMagnitude < MinTargetDistance * MinTargetDistance)
        //{
        //    diff = mousePositionInWorld - (Vector2)transform.position;
        //}

        if (mousePositionInWorld.x < transform.position.x)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            transform.localScale = Vector3.one;
        }

        var angle = AngleMath.VectorToAngle2D(diff);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, MinTargetDistance);
    }
}
