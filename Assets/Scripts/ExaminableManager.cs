using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminableManager : MonoBehaviour
{
	[SerializeField] private Transform _examineTarget;
	private Vector3 _originalPos;
	private Quaternion _originalRotation;
	private Vector3 _originalScale;

	private Examinable _currentExaminedObject;
	private bool _isExamining;
	[SerializeField] private float _rotateSpeed = 0.5f;

	void Update()
	{
		if (_isExamining == true)
		{
			if (Input.touchCount > 0)
			{
				Touch touch = Input.GetTouch(0);
				if (touch.phase == TouchPhase.Moved)
				{
					_currentExaminedObject.transform.Rotate(-touch.deltaPosition.y * _rotateSpeed, -touch.deltaPosition.x * _rotateSpeed, 0);
				}
			}
		}
	}

	public void PerformExamine(Examinable examinable)
	{
		_currentExaminedObject = examinable;

		//cache the examinable transform data so we can reset it
		_originalPos = _currentExaminedObject.transform.position;
		_originalRotation = _currentExaminedObject.transform.rotation;
		_originalScale = _currentExaminedObject.transform.localScale;

		//move the examinable to target position
		_currentExaminedObject.transform.position = _examineTarget.position;
		_currentExaminedObject.transform.parent = _examineTarget;

		//offset scale to fit examinable in view
		Vector3 offsetScale = _originalScale * examinable.examinedScaleOffset;
		_currentExaminedObject.transform.localScale = offsetScale;

		_isExamining = true;
	}

	public void PerformUnexamine()
	{
		_currentExaminedObject.transform.position = _originalPos;
		_currentExaminedObject.transform.rotation = _originalRotation;
		_currentExaminedObject.transform.localScale = _originalScale;

		_currentExaminedObject.transform.parent = null;
		_currentExaminedObject = null;

		_isExamining = false;
	}

}
