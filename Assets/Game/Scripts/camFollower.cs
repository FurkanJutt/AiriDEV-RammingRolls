using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class camFollower : MonoBehaviour
{
    // Use this for initialization


    public float MoveSpeed;
    Transform thisTrans;

    public Rigidbody rb;

 

    public Vector3 offset;
    public void Start()
    {

        thisTrans = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        rb.velocity = Vector3.forward * MoveSpeed * Time.deltaTime;


    }
}
