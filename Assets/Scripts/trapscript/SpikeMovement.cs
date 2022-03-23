using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    // Start is called before the first frame update      public GameObject apple;     public float freq;
    /* public GameObject apple;
    public float speed;

    public void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 2) * 2;
        apple.transform.position = new Vector3(transform.position.x, y, transform.position.z);
    } */
    //public float movementSpeed = 10;

    private Rigidbody rb;
    //private Vector3 endPosition = new Vector2(17, 3);
    //private Vector3 endPosition = new Vector3(19, 8, 0);
    // Use this for initialization
    public bool posit = true;
    private float InstantiationTimer = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody>();




    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v3 = transform.position;
        InstantiationTimer -= Time.deltaTime;
        if (InstantiationTimer <= 0 && posit == true)
        {
            v3.x += 0.9f;
            transform.position = v3;
            InstantiationTimer = 3;
            posit = false;
        }
        if (InstantiationTimer <= 0 && posit == false)
        {
            v3.x -= 0.9f;
            transform.position = v3;
            InstantiationTimer = 3;
            posit = true;
        }

        /* if (transform.position != endPosition)
        {

            transform.position = Vector3.MoveTowards(transform.position, endPosition, movementSpeed * Time.deltaTime);
        } */
    }
}
