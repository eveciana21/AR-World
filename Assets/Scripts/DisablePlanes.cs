using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DisablePlanes : MonoBehaviour
{
    private ARPlaneManager _planeManager;

    void Start()
    {
        _planeManager = GetComponent<ARPlaneManager>();
    }

    public void EnablePlaneDisplay(bool display)
    {
        _planeManager.enabled = display;
        foreach(var plane in _planeManager.trackables)
        {
            plane.gameObject.SetActive(display);
        }
    }

}
