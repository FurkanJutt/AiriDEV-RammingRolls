using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrignometricMovement : MonoBehaviour {

	public Vector3 MovementLimit;
	public Vector3 MovementFrequncy;
	private Vector3 StartPosition;
	private Vector3 FinalPosition;

	void Start () 
	{
		StartPosition = transform.localPosition;
	}
	void Update () 
	{
		
		transform.localPosition = Move ();
	}
	float timer=0;
	Vector3 Move()
	{
		timer += Time.deltaTime;
		FinalPosition.x = StartPosition.x + Mathf.Sin (timer * MovementFrequncy.x) * MovementLimit.x;
		FinalPosition.y = StartPosition.y + Mathf.Sin (timer * MovementFrequncy.y) * MovementLimit.y;
		FinalPosition.z = StartPosition.z + Mathf.Sin (timer * MovementFrequncy.z) * MovementLimit.z;
		return FinalPosition;
	}
}
