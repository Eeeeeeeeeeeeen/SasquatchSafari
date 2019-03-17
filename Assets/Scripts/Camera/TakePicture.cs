using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.DataModels;
using System.IO;

public class TakePicture : MonoBehaviour
{
    string screenshotFolderPath;
    public int PictureLimit = 10;
    public int PictureCount = 0;

    PlayerSessionManager playerManager;
    string dataPath;

    public AudioClip camera;
    AudioSource source;
    private bool isScoped = false;

    // Start is called before the first frame update
    void Start()
    {
        var gameManager = GameObject.Find("GameManager");
        playerManager = gameManager.GetComponent<PlayerSessionManager>();
        dataPath = "GameData/";
        source = GetComponent<AudioSource>();
        EventManager.StartListening("scope-out", () => this.isScoped = false);
        EventManager.StartListening("scope-in-end", () => this.isScoped = true);
    }

    // Update is called once per frame
    void Update()
    {
        if (PictureCount < PictureLimit && Input.GetButtonDown("Fire1") && isScoped)
        {
            OnClickScreenCaptureButton();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            SaveGameData();
        }
    }

    public void SaveGameData()
    {
        string dataAsJson = JsonUtility.ToJson(playerManager.playerGallery);
        Directory.CreateDirectory(dataPath);

        string filePath = dataPath + "/" + playerManager.PlayerSession + ".json";
        File.WriteAllText(filePath, dataAsJson);

    }

    public void OnClickScreenCaptureButton()
    {
        StartCoroutine(CaptureScreen());
    }

    public IEnumerator CaptureScreen()
    {

        PictureCount++;

        EventManager.TriggerEvent("snap");

        source.PlayOneShot(camera);
        yield return new WaitForEndOfFrame();

        var score = PictureScorer.instance.CalculateScore();

        var pictureLocation = $"{playerManager.ScreenshotFolderPath}{Guid.NewGuid()}.png";

        ScreenCapture.CaptureScreenshot(pictureLocation);

        var pictureData = new PictureModel() { PictureLocation = pictureLocation, Score = score };

        playerManager.playerGallery.Pictures.Add(pictureData);


        EventManager.TriggerEvent("snap-fin");
    }
}
