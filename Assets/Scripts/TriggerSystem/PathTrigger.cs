using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PathTrigger : MonoBehaviour
{
    public GameObject Source;
    public UnityEvent Event;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == this.Source)
        {
            this.Event.Invoke();
        }
    }
}
