using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Assets.DataModels;
using TMPro;

public class BestPhotos : MonoBehaviour
{
    public TextMeshProUGUI totalScoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        string file = PlayerPrefs.GetString("username") + ".json";
        string dataAsJson = File.ReadAllText($"GameData/{file}");
        var gameData = JsonUtility.FromJson<PlayerGallery>(dataAsJson);
        gameData.Pictures.OrderByDescending(x => x.Score);

        var shots = FindObjectsOfType<BestPhoto>();

        int loopCounter;
        if (gameData.Pictures.Count > 6)
        {
            loopCounter = 6;
        } else
        {
            loopCounter = gameData.Pictures.Count;
        }
        var totalScore = 0;
        for (int i = 0; i < loopCounter; i++)
        {
            var fileData = File.ReadAllBytes(gameData.Pictures[i].PictureLocation);
            var tex = new Texture2D(1218, 910);
            tex.LoadImage(fileData);

            shots[i].SetImage(tex, gameData.Pictures[i].Score);
            totalScore += gameData.Pictures[i].Score;
        }

        totalScoreDisplay.SetText(totalScore.ToString());
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
