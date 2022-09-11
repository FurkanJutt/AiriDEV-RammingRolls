using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Laser laserScript;
    public Material objectMat;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit: " + other.tag);
        if(other.tag == "Player")
        {
            other.GetComponent<Renderer>().material.color = laserScript.GetLaserColor();
            other.GetComponentInChildren<TrailRenderer>().startColor = laserScript.GetLaserColor();
            other.GetComponentInChildren<TrailRenderer>().endColor = laserScript.GetLaserColor();
            objectMat.color = laserScript.GetLaserColor();
        }
    }

    private void OnDestroy()
    {
        objectMat.color = Color.white;
    }
}
