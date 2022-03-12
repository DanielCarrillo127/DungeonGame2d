using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonscript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firepoint;
    public GameObject bullet;
    float timebetween;
    public float starttimebetween;
    void Start()
    {
        timebetween = starttimebetween;
    }

    // Update is called once per frame
    void Update()
    {
        if (timebetween <= 0)
        {
            Instantiate(bullet,firepoint.position,firepoint.rotation);
            timebetween = starttimebetween;
            
        }else
        {
            timebetween -= Time.deltaTime;
        }
    }
}
