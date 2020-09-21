using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//中型船

public class MiddleBoat : Boat_Class {

    private void Start()
    {
        SetBoat(8, 2f, 25);
        if (transform.tag != "Player")
        {
            GetSmallGun(transform.GetComponentsInChildren<SmallGun>());
        }
        transform.Find("Key").GetComponent<Body>().boatType = 1;
    }

    private void Update()
    {
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
