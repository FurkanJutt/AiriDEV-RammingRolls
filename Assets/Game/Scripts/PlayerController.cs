using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly Plane touchPlane = new Plane(Vector3.forward, new Vector3(0.0f, 0.0f, 0.0f));
    public float sensitivity = 0.16f;
    public float clampDelta = 42f;
    private Vector3 lastMousePos = new Vector3();
    public static PlayerController instance;
    public Rigidbody rb;
    public GameObject camera;
    public Vector3 CamVel;
    public bool mouseEnabled = true;


    private void Awake()
    {
        PlayerController.instance = this;
    }

    private void FixedUpdate()
    {
     //   CamVel = camRB.velocity;
        if (Input.GetMouseButtonDown(0))
            this.lastMousePos = Input.mousePosition;
        if (Input.GetMouseButton(0) && mouseEnabled)
        {
            Vector3 vector = this.lastMousePos - Input.mousePosition;
            this.lastMousePos = Input.mousePosition;
            vector = new Vector3(vector.x, 0, vector.y);

            Vector3 vector3 = Vector3.ClampMagnitude(vector, this.clampDelta);
            this.rb.AddForce(CamVel / 4.2f + (-vector3 * this.sensitivity - this.rb.velocity / 5f), ForceMode.VelocityChange);

        }
        else
        {
            if ((double)this.rb.velocity.magnitude >= (double)CamVel.magnitude)
                return;
            this.rb.AddForce(CamVel / 4.2f - this.rb.velocity / 3f, ForceMode.VelocityChange);
        }
    }

    private void Update()
    {
        if (this.rb.transform.position.z < camera.transform.position.z)
        {
            DestroyPlayer();
            GameManager.gm.ShowGameOver();
        }
    }

    bool over;
	IEnumerator OnCollisionEnter(Collision col)
	{

		if (col.transform.tag.Contains ("Enemy")) {
			if (!over) {
				over = true;
                DestroyPlayer();
                yield return new WaitForSeconds(1f);
                Time.timeScale = 0;
                GameManager.gm.ShowGameOver();
            }
		}
	}

    IEnumerator OnTriggerEnter(Collider incoming)
	{
        if (incoming.name.Contains ("Finish")) 
		{
			incoming.GetComponent<FinishEffect> ().FinishEffectobj.SetActive (true);

            yield return new WaitForSeconds(0.5f);
            GameManager.gm.ShowGameWin ();

		}
        if (incoming.gameObject.CompareTag("Hole"))
        {
            if (!over)
            {
                over = true;
                yield return new WaitForSeconds(1f);
                DestroyPlayer();
                yield return new WaitForSeconds(1f);
                Time.timeScale = 0;
                GameManager.gm.ShowGameOver();
            }
        }
    }

    private void DestroyPlayer()
    {
        GetComponent<MeshRenderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        GameObject obj = Instantiate(GameManager.gm.BallDestryEffect);
        obj.transform.position = transform.position;
    }
}
