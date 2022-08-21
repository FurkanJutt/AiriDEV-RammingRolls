using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour 
{

	public Vector3 moveLimit;
	void Start () 
	{
		fals ();
	}
	enum mov
	{
		left,
		rright
	}
	mov moves;

	void Update ()
	{
		if (move) 
		{
			
			switch(moves)
			{
			case mov.left:
				transform.position -= Vector3.right * Time.deltaTime *2;				
				if (transform.position.x <= -moveLimit.x) 
				{
					moves = mov.rright;
				}
				break;
				case mov.rright:
				transform.position += Vector3.right * Time.deltaTime*2;				
				if (transform.position.x >= moveLimit.x) 
				{
					moves = mov.left;
				}
				break;
			}
		}
		else
			{
				
			}

	}
	bool move;
	void fals(){
		Invoke ("tru",Random.Range(2f,3f));	
		move = false;
	}
	void tru(){
		Invoke ("fals",Random.Range(2f,4f));	
		move = true;
	}


}
