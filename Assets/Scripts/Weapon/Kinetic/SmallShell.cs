using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//小子弹

public class SmallShell : Shell_Class {


    private void Start()
    {
        Destroy(gameObject, 2);
    }

    private void Update()
    {
        
    }

}
