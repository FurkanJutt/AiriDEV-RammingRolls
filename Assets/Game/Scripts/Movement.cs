using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    Rigidbody rb,ringRb;

    public float speed = 6.69f;
    public Vector3 offset;
    public float smoothing = 1000;
    bool hit;
    public  bool jelly;
    int djump=0;


    void Start () {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();

    }
	Vector3 forwardoffset;

	void Update ()
	{

		if (!GameManager.gm.boolGameComplete && !GameManager.gm.boolGameOver) {
			
		
		
			transform.Translate (Vector3.forward * FindObjectOfType<CameraMovement> ().cameraSpeed * Time.deltaTime);
 
			if (Input.GetMouseButtonDown (0)) {
				Vector3 touchPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10);
				touchPos = Camera.main.ScreenToWorldPoint (touchPos);
				offset = transform.position - new Vector3 (touchPos.x, 0, 0);
				forwardoffset = transform.position - FindObjectOfType<CameraMovement> ().transform.position;

			}

			if (Input.GetMouseButton (0)) {
				Vector3 touchPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10);
				touchPos = Camera.main.ScreenToWorldPoint (touchPos);

				Vector3 newPos = new Vector3 (touchPos.x, transform.position.y, transform.position.z) + new Vector3 (offset.x, 0, 0);
				transform.position = Vector3.Lerp (transform.position, newPos, Time.deltaTime * smoothing);

			}
		}
       
    }

    void OnCollisionEnter(Collision col)
    {
		
		if (col.transform.tag.Contains("Enemy")) 
			{
				GetComponent<MeshRenderer> ().enabled = false;
				transform.GetChild (0).gameObject.SetActive (false);
				GameObject obj=	Instantiate (GameManager.gm.BallDestryEffect);
				obj.transform.position = transform.position;
				GameManager.gm.ShowGameOver ();
			}

    }
	IEnumerator OnTriggerEnter(Collider incoming)
	{
		if (incoming.name.Contains ("Finish")) {
			incoming.GetComponent<FinishEffect> ().FinishEffectobj.SetActive (true);

			yield return new WaitForSeconds(0.5f);
			GameManager.gm.ShowGameWin ();
		}	
	}
   

    void HitOff()
    {
        hit = false;
    }


  
}