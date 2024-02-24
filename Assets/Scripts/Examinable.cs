using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examinable : MonoBehaviour
{
    private DoubleTap _examinableManager;
    public float examinedScaleOffset = 0.5f;
    private bool _isBeingExamined = false;
    private Touch _touch;

    [SerializeField] private float _rotateSpeed = 0.5f;

    void Start()
    {
        _examinableManager = FindObjectOfType<DoubleTap>();
    }

    private void Update()
    {
        if (_isBeingExamined == true)
        {
            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);

                transform.Rotate(0, -_touch.deltaPosition.x * _rotateSpeed, _touch.deltaPosition.y * _rotateSpeed); // rotate along the y and z axis
            }
        }
    }

    public void SelectionUpdate() // this will be selected within the event AR Selection Interactable
    {
        _examinableManager.UpdateSelection(transform);
    }

    public void SetExamineState(bool isBeingExamined) // sets the examined state of the bool as true
    {
        _isBeingExamined = isBeingExamined;
    }
}
