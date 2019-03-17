using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BestPhoto : MonoBehaviour
{
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetImage(Texture2D image, int score)
    {
        GetComponent<RawImage>().texture = image;
        this.score.SetText(score.ToString());
    }
}
