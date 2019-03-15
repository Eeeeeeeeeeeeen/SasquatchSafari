using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTrigger : MonoBehaviour
{
    public GameObject Source;
    public TriggerEvent Event;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == this.Source)
        {
            this.Event.Fire();
        }
    }
}
