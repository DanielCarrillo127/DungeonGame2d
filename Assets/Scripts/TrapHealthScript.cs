using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHealthScript : MonoBehaviour
{
      // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player")
        {
            GameControlScript.health -= 1;
        }
        
    }
   

    // Update is called once per frame
    
}
