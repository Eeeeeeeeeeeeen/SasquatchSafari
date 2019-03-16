using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureScorer : MonoBehaviour
{ 
    public static PictureScorer pictureScorer;

    public static PictureScorer instance
    {
        get
        {
            if (!pictureScorer)
            {
                pictureScorer = FindObjectOfType(typeof(PictureScorer)) as PictureScorer;

                if (!pictureScorer)
                {
                    Debug.LogError("There needs to be one active PictureScorer script on a GameObject in your scene.");
                }
                else
                {
                    pictureScorer.Init();
                }
            }

            return pictureScorer;
        }
    }

    public Camera cam;

    public List<BodyPart> parts = new List<BodyPart>();

    void Init()
    {
        if (parts == null)
        {
            parts = new List<BodyPart>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int CalculateScore()
    {
        var runningScore = 0;
        foreach (BodyPart part in parts)
        {
            if(IsInView(part.gameObject))
            {
                RaycastHit raycast;
                if(Physics.Raycast(cam.transform.position, part.transform.position - cam.transform.position, out raycast))
                {
                    runningScore += GetBodyPartValue(raycast.collider.name.ToLower());
                    if(IsCentered(part.gameObject))
                    {
                        runningScore += GetBodyPartValue(raycast.collider.name.ToLower());
                    }
                }
            }
        }
        return runningScore;
    }
    
    int GetBodyPartValue(string partName)
    {
        if(partValues.TryGetValue(partName, out int value))
        {
            return value;
        }
        return 0;
    }

    bool IsCentered(GameObject gameObject)
    {
        var part2D = cam.WorldToViewportPoint(gameObject.transform.position);
        if ((part2D.x > 0.3 && part2D.x < 0.7) && (part2D.y > 0.3 && part2D.y < 0.7))
        {
            return true;
        }
        return false;
    }

    bool IsInView(GameObject gameObject)
    {
        var part2D = cam.WorldToViewportPoint(gameObject.transform.position);

        if((part2D.x > 0 && part2D.x < 1) && (part2D.y > 0 && part2D.y < 1))
        {
            return true;
        }
        return false;
    }

    public Dictionary<string, int> partValues = new Dictionary<string, int>()
    {
        {"head", 75 },
        {"torso", 40 },
        {"arm", 10 },
        {"hand", 15 },
        {"leg", 5 },
        {"foot", 25 },
    };
}
