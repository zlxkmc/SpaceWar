using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//场景Key
//boatId 玩家所选的船的id
//

public class GameManager : MonoBehaviour {

    public GameObject WarPos;

    public static GameManager _instance;

    private void Awake()
    {
        _instance = this;
    }

}
