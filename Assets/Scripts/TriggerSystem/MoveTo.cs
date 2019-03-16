using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public float AnimateTime = 1f;
    public Transform Waypoints;

    private List<Transform> Targets = new List<Transform>();
    private bool movementStarted = false;
    private Vector3 velocity;
    private int currentTarget;
    private Vector3 startPosition;
    private float elapsedTime = 0f;
    private float previousStep = 0f;

    void Start()
    {
        startPosition = transform.position;
        foreach (Transform child in Waypoints)
        {
            Targets.Add(child);
        }
    }

    void Update()
    {
        if (movementStarted)
        {
            elapsedTime += Time.deltaTime;
            float stepPortion = (elapsedTime % (AnimateTime / Targets.Count)) / (AnimateTime / Targets.Count);

            if (stepPortion < previousStep)
            {
                if (currentTarget == Targets.Count - 1)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    startPosition = Targets[currentTarget].position;
                    currentTarget++;
                }
            }

            transform.position = Vector3.Lerp(startPosition, Targets[currentTarget].position, stepPortion);
            previousStep = stepPortion;
        }
    }

    public void StartMovement()
    {
        movementStarted = true;
        currentTarget = 0;
    }
}
