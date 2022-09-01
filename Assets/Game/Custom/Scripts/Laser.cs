using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer laser;
    public GameObject origin;
    public GameObject end;
    public GameObject player;
    public Color randomColor;
    public bool playerPosPassed = false;

    // Start is called before the first frame update
    void Start()
    {
        randomColor = new Color(
            Random.Range(0f, 1f), //Red
            Random.Range(0f, 1f), //Green
            Random.Range(0f, 1f), //Blue
            1//Alpha (transparency)
        );

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(randomColor, 0.0f)},
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f)}
            );
        laser.colorGradient = gradient;
    }

    // Update is called once per frame
    void Update()
    {
        laser.SetPosition(0, origin.transform.position);
        laser.SetPosition(1, end.transform.position);

        //if (player.GetComponent<Rigidbody>().transform.position.z >= 34)
        //{
        //    playerPosPassed = true;
        //    player.GetComponent<Renderer>().material.color = randomColor;
        //}
    }
}
