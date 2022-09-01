using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour
{
    [SerializeField] private List<GameObject> maskObj;

    private void Start()
    {
        maskObj.Add(GameObject.Find("Platfrom"));
        maskObj.Add(GameObject.Find("BorderLeft"));
        maskObj.Add(GameObject.Find("BorderRight"));

        for (int i = 0; i < maskObj.Count; i++)
        {
            maskObj[i].GetComponent<MeshRenderer>().material.renderQueue = 3002;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<SphereCollider>().enabled = false;
            other.GetComponent<PlayerController>().mouseEnabled = false;
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag.Contains("NonDropable"))
            other.GetComponent<Collider>().enabled = true;
        else
            other.GetComponent<Collider>().enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<SphereCollider>().enabled = true;
        }
    }
}
