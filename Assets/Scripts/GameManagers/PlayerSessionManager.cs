using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Assets.DataModels;

public class PlayerSessionManager : MonoBehaviour
{
    [HideInInspector]
    public Guid PlayerSession;
    [HideInInspector]
    public string ScreenshotFolderPath;

    public PlayerGallery playerGallery;
    // Start is called before the first frame update
    void Start()
    {
        PlayerSession = Guid.NewGuid();
        ScreenshotFolderPath = $"Screenshots/{PlayerSession.ToString()}/";

        playerGallery = new PlayerGallery(PlayerSession.ToString());

        Directory.CreateDirectory(ScreenshotFolderPath);
    }
}
