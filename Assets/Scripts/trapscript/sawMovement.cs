using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawMovement : MonoBehaviour
{
    public Vector2 Velocity;
    private Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _rigidbody2D.velocity = Velocity;
    }
}
