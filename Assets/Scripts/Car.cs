using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    public PathCreator PathCreator;

    public float speed = 0.1f;
    float distanceTravelled;

    void Start()
    {
        if (PathCreator == null)
        {
            throw new System.ArgumentException("No path set up!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();
    }

    void Move()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = this.PathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
        transform.rotation = this.PathCreator.path.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
    }

    public void ChangeSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }
}
