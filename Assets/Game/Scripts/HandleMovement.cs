using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMovement : MonoBehaviour {

	private Rigidbody rb;
	public Vector2 mousePos;
	public Vector3 offset;
	private bool clicked;
	public Vector3 s;


	Vector3 pos;
	public Vector3 BallPos;
	private void Start () 
	{
		rb = GetComponent<Rigidbody> ();

	}
	private void FixedUpdate () 
	{

	if (Input.GetMouseButton (0)) 
		{
			if (!clicked) 
			{
				clicked = true;
				offset =  transform.position - FindObjectOfType<CameraMovement> ().transform.position ;
			}
			mousePos = Camera.main.ScreenToViewportPoint (Input.mousePosition);
			Vector3 p = new Vector3 (mousePos.x ,0,mousePos.y+offset.z);
			rb.MovePosition (p);
//			offset = transform.position;
//			pos = new Vector3(Input.mousePosition.x, transform.position.y,Input.mousePosition.y );
//			transform.position = Camera.main.ScreenToWorldPoint(pos);
		} 
		else 
		{
			rb.MovePosition (transform.position + new Vector3 (0, 0,FindObjectOfType<CameraMovement> ().cameraSpeed));
			clicked = false;
		} 
	}

}
