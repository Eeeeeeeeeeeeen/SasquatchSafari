using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScope : MonoBehaviour
{
    public Camera PlayerCamera;
    public Camera Cam2000Camera;
    bool animating = false;
    bool IsScopedIn = false;



    void Start()
    {
        EventManager.StartListening("scope-in", ScopeIn);
        EventManager.StartListening("scope-out", ScopeOut);
        EventManager.StartListening("scope-in-end", SwitchToCamera);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && !animating)
        {
            if (IsScopedIn)
            {
                EventManager.TriggerEvent("scope-out");
            }
            else
            {
                EventManager.TriggerEvent("scope-in");
            }
        }
    }

    void ScopeIn()
    {
        if (!IsScopedIn)
        {
            animating = true;
            GetComponent<Animator>().SetTrigger("EnterScope");
        }
    }

    void ScopeOut()
    {
        if (IsScopedIn)
        {
            animating = true;
            GetComponent<Animator>().SetTrigger("ExitScope");
            SwitchToPlayer();
        }
    }

    void OnAnimationScopeInEnd()
    {
        EventManager.TriggerEvent("scope-in-end");
        animating = false;
    }

    void OnAnimationScopeOutEnd()
    {
        EventManager.TriggerEvent("scope-out-end");
        animating = false;
    }

    void SwitchToPlayer()
    {
        IsScopedIn = false;
        Cam2000Camera.enabled = false;
        PlayerCamera.enabled = true;
    }

    void SwitchToCamera()
    {
        IsScopedIn = true;
        PlayerCamera.enabled = false;
        Cam2000Camera.enabled = true;
    }


}
