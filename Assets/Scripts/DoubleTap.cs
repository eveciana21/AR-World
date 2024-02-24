using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class DoubleTap : MonoBehaviour
{
	[SerializeField] private ARPlacementInteractable _placementInteractable; //placement interactable
	[SerializeField] private Transform _examineTarget; //examine target container under Camera child

	private Transform _examinableOrigin; // original transform of the examinable

	//cache original position, scale, rotation
	private Vector3 _originalPos; 
	private Vector3 _originalScale;
	private Quaternion _originalRotation;

	private Examinable _examinable; //grabs the Examine Object Script

	private Transform _currentSelected; // object currently selected
	private Transform _examinedObject; // object you are currently examining

	private float _lastTapTime; 
	[SerializeField] private float _doubleTapThreshold = 0.3f; //max time between taps allowed

	private bool _isExamining = false;


	void Update()
	{
		if (Input.touchCount == 1)
        {
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began)
            {
				if (Time.time - _lastTapTime <= _doubleTapThreshold) //if the current time minus lastTapTime is less than or equal to doubleTapThreshold, perform examine and reset lastTapTime
                {
					Debug.Log("#### Double Tapped ####"); 
					_lastTapTime = 0;
					Examine(); 
                }
                else
                {
					Debug.Log("#### Tap Detected ####"); //first tap detected. lastTapTime is equal to the current time
					_lastTapTime = Time.time;
                }
            }
        }
	}

	public void UpdateSelection(Transform examineObject) 
    {
		Debug.Log("#### Selection Updated ####");
		_currentSelected = examineObject; // current object selected is set to the examinable object on the examinable script
    }

	private void Examine()
    {
		// if not currently selecting object, examine the selected object. Otherwise, if examining object, return to its original position
		if (_isExamining == false)
        {
            ExamineSelected();
        }
        else
        {
			ReturnSelected();
        }
    }

	public void ExamineSelected()
	{
		print("#### Examine Selected ####");

		if (_currentSelected == null) // if there is no currently selected object, do nothing
		{
			return;
		}

		//cache the examinable transform data of the parent object
		_examinableOrigin = _currentSelected.parent;

		_originalPos = _currentSelected.localPosition;
		_originalRotation = _currentSelected.localRotation;
		_originalScale = _currentSelected.localScale;

		_examinable = _currentSelected.GetComponent<Examinable>();

		//move the examinable to target position
		_currentSelected.parent = _examineTarget;
		_currentSelected.localPosition = Vector3.zero;
		_currentSelected.localRotation = Quaternion.identity;

		//set current object selected to the examined object
		_examinedObject = _currentSelected;
		_examinable.SetExamineState(true);
		_placementInteractable.enabled = false;

		_isExamining = true;
	}

	public void ReturnSelected()
	{
		print("#### Return Selected ####");

		//reset transform data to original position
		_examinedObject.parent = _examinableOrigin;
		_examinedObject.localPosition = _originalPos;
		_examinedObject.localScale = _originalScale;
		_examinedObject.localRotation = _originalRotation;

		//not currently examining
		_examinable.SetExamineState(false);
		_placementInteractable.enabled = true;

		_currentSelected = null;
		_examinedObject = null;
		_isExamining = false;
	}
}
