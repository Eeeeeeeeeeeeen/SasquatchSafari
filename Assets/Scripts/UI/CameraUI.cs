﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraUI : MonoBehaviour
{
    public Text PhotoCount;
    private TakePicture pictureTaker;
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        pictureTaker = GameObject.Find("GameManager").GetComponent<TakePicture>();
        EventManager.StartListening("snap", PictureTaken);
        EventManager.StartListening("scope-out", ScopeOut);
        EventManager.StartListening("scope-in-end", ScopeIn);
        canvas = GetComponent<Canvas>();

        canvas.enabled = false;
        UpdatePhotoCount();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void ScopeIn()
    {
        canvas.enabled = true;
    }

    void ScopeOut()
    {
        canvas.enabled = false;
    }

    void PictureTaken()
    {
        UpdatePhotoCount();
    }

    void UpdatePhotoCount()
    {
        PhotoCount.text = $"{pictureTaker.PictureCount}/{pictureTaker.PictureLimit}";
    }
}