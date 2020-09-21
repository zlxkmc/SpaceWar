using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatManager : MonoBehaviour {

    public GameObject[] playerBoats;

    public GameObject[] teammateBoats;

    public GameObject[] enemyBoats;

    public static BoatManager _instance;

    private void Awake()
    {
        _instance = this;
    }
}
