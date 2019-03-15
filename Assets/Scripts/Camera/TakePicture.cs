using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TakePicture : MonoBehaviour
{
    string screenshotFolderPath;
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
        if(Input.GetButtonDown("Fire1")) {
            ScreenCapture.CaptureScreenshot($"{screenshotFolderPath}{Guid.NewGuid()}.png");
        }
    }
}
