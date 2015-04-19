using UnityEngine;
using System.Collections;

public class ScaleNormalizer : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.parent.localScale.x < 0)
        {
            // Invert the mirror for the gun to function properly
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }
}
