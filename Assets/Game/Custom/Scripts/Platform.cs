using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject hole;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, new Vector3(0f, 0.105f, -23f), Quaternion.identity);
        int holesCount = Random.Range(2, 6);
        for (int i = 0; i < holesCount; i++)
        {
            Instantiate(hole, new Vector3(Random.Range(-5.125f, 5.125f), -0.32f, Random.Range(-8f, 65f)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
