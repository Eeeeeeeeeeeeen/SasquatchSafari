using System;
using System.IO;
using UnityEngine;

public class PlayerSessionManager : MonoBehaviour
{
    [HideInInspector]
    public Guid PlayerSession;
    [HideInInspector]
    public string ScreenshotFolderPath;
    // Start is called before the first frame update
    void Start()
    {
        PlayerSession = Guid.NewGuid();
        ScreenshotFolderPath = $"Screenshots/{PlayerSession.ToString()}/";

        Directory.CreateDirectory(ScreenshotFolderPath);
    }
}
