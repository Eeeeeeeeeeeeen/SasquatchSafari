using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject Target;
    public Vector3 Offset;

    void LateUpdate()
    {
        transform.position = Target.transform.position + Offset;
    }
}
