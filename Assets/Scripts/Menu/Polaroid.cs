using Assets.DataModels;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Polaroid : MonoBehaviour
{
    public GameObject Text, Image;
    // Start is called before the first frame update
    void Start()
    {
        var zRot = Random.Range(-25, 25);
        var xPos = Random.Range(-20, 20);
        var yPos = Random.Range(-20, 20);

        transform.TransformPoint(new Vector3(xPos, yPos, transform.position.z));
        transform.Rotate(0, 0, zRot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetProps(PolaroidModel polaroidModel)
    {
        Text.GetComponent<TextMeshProUGUI>().SetText($"{polaroidModel.PlayerName} - {polaroidModel.PictureModel.Score} pts");

        var fileData = File.ReadAllBytes(polaroidModel.PictureModel.PictureLocation);
        var tex = new Texture2D(1218, 910);
        tex.LoadImage(fileData);

        Image.GetComponent<RawImage>().texture = tex;
    }
}
