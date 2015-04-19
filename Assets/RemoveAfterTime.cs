using UnityEngine;
using System.Collections;

public class RemoveAfterTime : MonoBehaviour
{
    public float Time = 1;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, Time);
    }

}
