using UnityEngine;
using System.Collections;

public class LegsAnimator : MonoBehaviour
{
    public AnimationClip Stand;
    public AnimationClip Walk;
    public float NormalWalkingSpeed = 45;

    private Rigidbody2D rigidbody2d;
    private GroundDetector groundDetector;
    private Animator animator;

    private AnimationClip currentAnimationClip;

    // Use this for initialization
    void Awake()
    {
        rigidbody2d = GetComponentInParent<Rigidbody2D>();
        groundDetector = GetComponentInParent<GroundDetector>();
        animator = GetComponent<Animator>();
        currentAnimationClip = Stand;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float velocityX = rigidbody2d.velocity.x;
        bool isOnGround = groundDetector.IsOnGround();

        if (velocityX != 0)
        {
            if (velocityX > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        if (!Mathf.Approximately(0, velocityX) && isOnGround)
        {
            if (currentAnimationClip == Stand)
            {
                currentAnimationClip = Walk;
                animator.Play(Walk.name);
            }
            animator.speed = Mathf.Abs(velocityX) / NormalWalkingSpeed;
        }
        else
        {
            if (currentAnimationClip == Walk)
            {
                currentAnimationClip = Stand;
                animator.Play(Stand.name);
            }
        }
    }
}
