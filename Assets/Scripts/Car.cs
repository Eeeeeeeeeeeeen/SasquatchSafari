using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    public PathCreator PathCreator;
    public float startLocation = 0f;
    public float speed = 0.1f;
    float distanceTravelled;
    private EndOfPathInstruction PathLoop = EndOfPathInstruction.Loop;

    void Start()
    {
        if (PathCreator == null)
        {
            throw new System.ArgumentException("No path set up!");
        }
        distanceTravelled = startLocation;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();
    }

    void Move()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = this.PathCreator.path.GetPointAtDistance(distanceTravelled, PathLoop);
        transform.rotation = this.PathCreator.path.GetRotationAtDistance(distanceTravelled, PathLoop);
    }

    public void ChangeSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }
}
