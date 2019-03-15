using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        PictureScorer.instance.parts.Add(this);
    }

    void OnDisable()
    {
        PictureScorer.instance.parts.Remove(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
