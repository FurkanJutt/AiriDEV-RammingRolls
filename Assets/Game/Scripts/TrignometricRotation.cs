using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrignometricRotation : MonoBehaviour {

	public Vector3 RotationLimit;
	public Vector3 RotationFrequency;
	private Vector3 StartRotation;
	private Vector3 FinalPosition;
	// Use this for initialization

	void Start () 
	{
		StartRotation = transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () 
	{
		FinalPosition.x = StartRotation.x + Mathf.Sin (Time.timeSinceLevelLoad * RotationFrequency.x) * RotationLimit.x;
		FinalPosition.y = StartRotation.y + Mathf.Sin (Time.timeSinceLevelLoad * RotationFrequency.y) * RotationLimit.y;
		FinalPosition.z = StartRotation.z + Mathf.Sin (Time.timeSinceLevelLoad * RotationFrequency.z) * RotationLimit.z;
		transform.localEulerAngles = new Vector3 (FinalPosition.x,FinalPosition.y,FinalPosition.z);
	}
}
