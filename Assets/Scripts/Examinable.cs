using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examinable : MonoBehaviour
{
	private ExaminableManager _examinableManager;
	public float examinedScaleOffset = 1f;

	void Start()
	{
		_examinableManager = FindObjectOfType<ExaminableManager>();
	}

	public void RequestExamine()
	{
		_examinableManager.PerformExamine(this);
	}
	public void RequestUnexamine()
	{
		_examinableManager.PerformUnexamine();
	}

}
