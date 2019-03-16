using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.DataModels;
using System.IO;

public class TakePicture : MonoBehaviour
{
    PlayerSessionManager playerManager;
    string dataPath;
    // Start is called before the first frame update
    void Start()
    {
        var gameManager = GameObject.Find("GameManager");
        playerManager = gameManager.GetComponent<PlayerSessionManager>();
        dataPath = "GameData/";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            var score = PictureScorer.instance.CalculateScore();

            var pictureLocation = $"{playerManager.ScreenshotFolderPath}{Guid.NewGuid()}.png";

            ScreenCapture.CaptureScreenshot(pictureLocation);

            var pictureData = new PictureModel() { PictureLocation = pictureLocation, Score = score };

            playerManager.playerGallery.Pictures.Add(pictureData);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            SaveGameData();
        }
    }

    private void SaveGameData()
    {
        string dataAsJson = JsonUtility.ToJson(playerManager);
        Directory.CreateDirectory(dataPath);

        string filePath = dataPath + "/" + playerManager.PlayerSession + ".json";
        File.WriteAllText(filePath, dataAsJson);

    }
}
