using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public float AnimateTime = 1f;
    public Transform Target;

    private bool movementStarted = false;
    private Vector3 velocity;

    void Update()
    {
        if (movementStarted)
        {
            transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref velocity, AnimateTime);

            if (transform.position == Target.position)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void StartMovement()
    {
        movementStarted = true;
    }
}
