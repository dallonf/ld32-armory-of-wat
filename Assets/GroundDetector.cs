﻿using UnityEngine;
using System.Collections;

public class GroundDetector : MonoBehaviour
{
    public float Distance = 0.1f;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidbody;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public bool IsOnGround()
    {
        var result = Physics2D.BoxCast((Vector2)transform.position + boxCollider.offset, boxCollider.size, 0, -Vector2.up, Distance);
        return !!result;
    }
}
