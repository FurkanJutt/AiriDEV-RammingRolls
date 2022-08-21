using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public float cameraSpeed = 0.04f;
	public Rigidbody thisrgbd;
	public float speed;
	private void Update ()
	{
		
		if (!GameManager.gm.boolGameComplete && !GameManager.gm.boolGameOver)
		{
			//thisrgbd.velocity = new Vector3 (0, 0, speed);
			transform.position += Time.deltaTime * Vector3.forward * cameraSpeed;
		}
	}

}