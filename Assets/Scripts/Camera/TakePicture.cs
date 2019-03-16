using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TakePicture : MonoBehaviour
{
    string screenshotFolderPath;
    public int PictureLimit = 10;
    public int PictureCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        var gameManager = GameObject.Find("GameManager");
        var playerManager = gameManager.GetComponent<PlayerSessionManager>();

        screenshotFolderPath = playerManager.ScreenshotFolderPath;
    }

    // Update is called once per frame
    void Update()
    {
        if (PictureCount < PictureLimit && Input.GetButtonDown("Fire1"))
        {
            PictureCount++;
            ScreenCapture.CaptureScreenshot($"{screenshotFolderPath}{Guid.NewGuid()}.png");
            EventManager.TriggerEvent("snap");
        }
    }
}
