using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPropeller : MonoBehaviour
{
    [SerializeField] private GameObject _propellerCenter;
    [SerializeField] private float _propellerSpeed = 20f;

    private bool _propellerEnabled;

    void Update()
    {
        if (_propellerEnabled)
        {
            transform.RotateAround(_propellerCenter.transform.position, Vector3.up, _propellerSpeed * Time.deltaTime);
        }
    }

    public void EnablePropeller()
    {
        _propellerEnabled = true;
    }
    public void DisablePropeller()
    {
        _propellerEnabled = false;
    }
}
