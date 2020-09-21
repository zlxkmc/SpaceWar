using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//大型船

public class BigBoat : Boat_Class {

    private void Start()
    {
        SetBoat(3, 0.4f, 10);
        if (transform.tag != "Player")
        {
            GetSmallGun(transform.GetComponentsInChildren<SmallGun>());
        }
        transform.Find("Key").GetComponent<Body>().boatType = 2;
    }

    private void Update()
    {

        if(transform.tag == "Player")
        {
            MustMethodUp();
        }
        else
        {
            AI_target();
            AI_move();
        }
    }
}
