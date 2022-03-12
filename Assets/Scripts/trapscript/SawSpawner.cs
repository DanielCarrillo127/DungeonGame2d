using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpawner : MonoBehaviour
{
    public GameObject Saw;
    void Start()
    {
        InvokeRepeating("SpawnSaw",0,2);
    
    }

    // Update is called once per frame
    void SpawnSaw()
    {
        Instantiate(Saw, transform.position, Quaternion.identity);
    }
}
