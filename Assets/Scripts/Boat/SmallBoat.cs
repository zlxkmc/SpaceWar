using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//小型船

public class SmallBoat : Boat_Class {


    private void Start()
    {
        SetBoat(26, 13, 100);
        if (transform.tag != "Player")
        { 
            GetSmallGun(transform.GetComponentsInChildren<SmallGun>());
        }
        transform.Find("Key").GetComponent<Body>().boatType = 0;
    }

    private void Update () {

        if (transform.tag == "Player")
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
