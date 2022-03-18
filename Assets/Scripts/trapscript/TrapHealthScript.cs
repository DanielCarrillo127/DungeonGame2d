using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameControlScript.health -= 1;
            

            if (gameObject.tag == "TrapRemove")
            {
                Destroy(gameObject);

            }

        }
        else
        {
            if (gameObject.tag == "TrapRemove")
            {
                Destroy(gameObject);

            }
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameControlScript.health -= 1;
        }
    }

    // Update is called once per frame

}
